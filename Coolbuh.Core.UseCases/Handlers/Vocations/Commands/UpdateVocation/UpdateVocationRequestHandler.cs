using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using Coolbuh.Core.UseCases.Handlers.Vocations.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.Vocations.Commands.UpdateVocation
{
    /// <summary>
    /// Обработчик команды "Обновить отпуск"
    /// </summary>
    public class UpdateVocationRequestHandler : IRequestHandler<UpdateVocationRequest, VocationDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IVocationsService _vocationsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="vocationsService">Доменный сервис "Отпуска"</param>
        public UpdateVocationRequestHandler(IDbContext dbContext, IVocationsService vocationsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _vocationsService = vocationsService ?? throw new ArgumentNullException(nameof(vocationsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Отпуск"</returns>
        public async Task<VocationDto> Handle(UpdateVocationRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Vocation == null) throw new InvalidOperationException("request.Vocation is null");

            await CheckUpdateVocationDtoAsync(request.Vocation, cancellationToken);

            var vocation = request.Vocation.MapVocation();

            _vocationsService.ValidationEntity(vocation);

            _dbContext.Vocations.Update(vocation);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return vocation.MapVocationDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Отпуск"
        /// </summary>
        /// <param name="vocation">DTO обновления "Отпуск"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task CheckUpdateVocationDtoAsync(UpdateVocationDto vocation, CancellationToken cancellationToken)
        {
            if (vocation == null) throw new ArgumentNullException(nameof(vocation));

            if (!await _dbContext.Vocations.AsNoTracking()
                .AnyAsync(rec => rec.Id == vocation.Id, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутня відпустка в базі (id: {vocation.Id})");

            if (!await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == vocation.EmployeeCardId, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутня картка робітника в базі з {vocation.EmployeeCardId}");

            if (!await _dbContext.ListDepartments.AsNoTracking()
                .AnyAsync(rec => rec.Id == vocation.DepartmentId, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутній підрозділ в базі з {vocation.DepartmentId}");
        }
    }
}
