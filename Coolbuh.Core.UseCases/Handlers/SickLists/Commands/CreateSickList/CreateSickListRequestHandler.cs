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

namespace Coolbuh.Core.UseCases.Handlers.SickLists.Commands.CreateSickList
{
    /// <summary>
    /// Обработчик команды "Создать больничный лист"
    /// </summary>
    public class CreateSickListRequestHandler : IRequestHandler<CreateSickListRequest, SickListDto>
    {
        private readonly IDbContext _dbContext;
        private readonly ISickListsService _sickListsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="sickListsService">Доменный сервис "Больничные листы"</param>
        public CreateSickListRequestHandler(IDbContext dbContext, ISickListsService sickListsService)
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
        public async Task<SickListDto> Handle(CreateSickListRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.SickList == null) throw new InvalidOperationException("request.SickList is null");

            await CheckCreateSickListDtoAsync(request.SickList, cancellationToken);

            var sickList = request.SickList.MapSickList();

            _sickListsService.ValidationEntity(sickList);

            await _dbContext.SickLists.AddAsync(sickList, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return sickList.MapSickListDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Больничный лист"
        /// </summary>
        /// <param name="sickList">DTO создания "Больничный лист"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task CheckCreateSickListDtoAsync(CreateSickListDto sickList, CancellationToken cancellationToken)
        {
            if (sickList == null) throw new ArgumentNullException(nameof(sickList));

            if (!await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == sickList.EmployeeCardId, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутня картка робітника в базі з {sickList.EmployeeCardId}");

            if (!await _dbContext.ListDepartments.AsNoTracking()
                .AnyAsync(rec => rec.Id == sickList.DepartmentId, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутній підрозділ в базі з {sickList.DepartmentId}");
        }
    }
}
