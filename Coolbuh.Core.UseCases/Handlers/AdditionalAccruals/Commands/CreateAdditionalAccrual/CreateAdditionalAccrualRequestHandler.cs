using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.CreateAdditionalAccrual
{
    /// <summary>
    /// Обработчик команды "Создать дополнительное начисление"
    /// </summary>
    public class CreateAdditionalAccrualRequestHandler
        : IRequestHandler<CreateAdditionalAccrualRequest, AdditionalAccrualDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IAdditionalAccrualsService _additionalAccrualsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="additionalAccrualsService">Доменный сервис "Дополнительные начисления"</param>
        public CreateAdditionalAccrualRequestHandler(IDbContext dbContext, IAdditionalAccrualsService additionalAccrualsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _additionalAccrualsService = additionalAccrualsService ??
                                         throw new ArgumentNullException(nameof(additionalAccrualsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Дополнительное начисление"</returns>
        public async Task<AdditionalAccrualDto> Handle(CreateAdditionalAccrualRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AdditionalAccrual == null)
                throw new InvalidOperationException("request.AdditionalAccrual is null");

            await CheckCreateAdditionalAccrualDtoAsync(request.AdditionalAccrual, cancellationToken);

            var additionalAccrual = request.AdditionalAccrual.MapAdditionalAccrual();

            _additionalAccrualsService.ValidationEntity(additionalAccrual);

            await _dbContext.AdditionalAccruals.AddAsync(additionalAccrual, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return additionalAccrual.MapAdditionalAccrualDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Дополнительное начисление"
        /// </summary>
        /// <param name="additionalAccrual">DTO создания "Дополнительное начисление"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task CheckCreateAdditionalAccrualDtoAsync(CreateAdditionalAccrualDto additionalAccrual,
            CancellationToken cancellationToken)
        {
            if (!await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == additionalAccrual.EmployeeCardId, cancellationToken))
                throw new NotFoundEntityUseCaseException(
                    $"Відсутня картка робітника в базі з id {additionalAccrual.EmployeeCardId}");

            if (!await _dbContext.ListDepartments.AsNoTracking()
                .AnyAsync(rec => rec.Id == additionalAccrual.DepartmentId, cancellationToken))
                throw new NotFoundEntityUseCaseException(
                    $"Відсутній підрозділ в базі з id {additionalAccrual.DepartmentId}");

            if (!await _dbContext.ListAdditionalAccrualTypes.AsNoTracking()
                .AnyAsync(rec => rec.Id == additionalAccrual.AdditionalAccrualTypeId, cancellationToken))
                throw new NotFoundEntityUseCaseException(
                    $"Відсутній тип додаткового нарахування в базі з id {additionalAccrual.AdditionalAccrualTypeId}");
        }
    }
}
