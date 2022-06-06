using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.UpdateAdditionalPayment
{
    /// <summary>
    /// Обработчик команды "Обновить дополнительную выплату"
    /// </summary>
    public class UpdateAdditionalPaymentRequestHandler
        : IRequestHandler<UpdateAdditionalPaymentRequest, AdditionalPaymentDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IAdditionalPaymentsService _additionalPaymentsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="additionalPaymentsService">Доменный сервис "Дополнительные выплаты"</param>
        public UpdateAdditionalPaymentRequestHandler(IDbContext dbContext,
            IAdditionalPaymentsService additionalPaymentsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _additionalPaymentsService
                = additionalPaymentsService ?? throw new ArgumentNullException(nameof(additionalPaymentsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Дополнительная выплата"</returns>
        public async Task<AdditionalPaymentDto> Handle(UpdateAdditionalPaymentRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AdditionalPayment == null) throw new NullReferenceException(nameof(request.AdditionalPayment));

            await CheckUpdateAdditionalPaymentDtoAsync(request.AdditionalPayment, cancellationToken);

            var additionalPayment = request.AdditionalPayment.MapAdditionalPayment();

            _additionalPaymentsService.ValidationEntity(additionalPayment);

            _dbContext.AdditionalPayments.Update(additionalPayment);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return additionalPayment.MapAdditionalPaymentDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Дополнительная выплата"
        /// </summary>
        /// <param name="additionalPayment">DTO обновления "Дополнительная выплата"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckUpdateAdditionalPaymentDtoAsync(UpdateAdditionalPaymentDto additionalPayment,
            CancellationToken cancellationToken)
        {
            if (additionalPayment == null) throw new NullReferenceException(nameof(additionalPayment));

            if (await _dbContext.AdditionalPayments.AsNoTracking()
                .AnyAsync(rec => rec.Id == additionalPayment.Id, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня додаткова виплата в базі (id: {additionalPayment.Id})");

            if (await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == additionalPayment.EmployeeCardId, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException(
                    $"Відсутня картка робітника в базі з {additionalPayment.EmployeeCardId}");

            if (await _dbContext.ListAdditionalPaymentTypes.AsNoTracking()
                .AnyAsync(rec => rec.Id == additionalPayment.AdditionalPaymentTypeId, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException(
                    $"Відсутній тип додаткової виплати в базі з {additionalPayment.AdditionalPaymentTypeId}");
        }
    }
}
