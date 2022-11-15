using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using Coolbuh.Core.UseCases.Handlers.SickLists.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.SickLists.Commands.UpdateSickList
{
    /// <summary>
    /// Обработчик команды "Обновить больничный лист"
    /// </summary>
    public class UpdateSickListRequestHandler : IRequestHandler<UpdateSickListRequest, SickListDto>
    {
        private readonly IDbContext _dbContext;
        private readonly ISickListsService _sickListsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="sickListsService">Доменный сервис "Больничные листы"</param>
        public UpdateSickListRequestHandler(IDbContext dbContext, ISickListsService sickListsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _sickListsService = sickListsService ?? throw new ArgumentNullException(nameof(sickListsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Больничный лист"</returns>
        public async Task<SickListDto> Handle(UpdateSickListRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.SickList == null) throw new InvalidOperationException("request.SickList is null");

            await CheckUpdateSickListDtoAsync(request.SickList, cancellationToken);

            var sickList = request.SickList.MapSickList();

            _sickListsService.ValidationEntity(sickList);

            _dbContext.SickLists.Update(sickList);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return sickList.MapSickListDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Больничный лист"
        /// </summary>
        /// <param name="sickList">DTO обновления "Больничный лист"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task CheckUpdateSickListDtoAsync(UpdateSickListDto sickList, CancellationToken cancellationToken)
        {
            if (sickList == null) throw new ArgumentNullException(nameof(sickList));

            if (!await _dbContext.SickLists.AsNoTracking()
                .AnyAsync(rec => rec.Id == sickList.Id, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутній лікарняний в базі (id: {sickList.Id})");

            if (!await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == sickList.EmployeeCardId, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутня картка робітника в базі з {sickList.EmployeeCardId}");

            if (!await _dbContext.ListDepartments.AsNoTracking()
                .AnyAsync(rec => rec.Id == sickList.DepartmentId, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутній підрозділ в базі з {sickList.DepartmentId}");
        }
    }
}
