using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using Coolbuh.Core.UseCases.Handlers.Payments.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Commands.UpdatePayment
{
    /// <summary>
    /// Обработчик команды "Обновить выплату"
    /// </summary>
    public class UpdatePaymentRequestHandler : IRequestHandler<UpdatePaymentRequest, PaymentDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IPaymentsService _paymentsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="paymentsService">Доменный сервис "Выплаты"</param>
        public UpdatePaymentRequestHandler(IDbContext dbContext, IPaymentsService paymentsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _paymentsService = paymentsService ?? throw new ArgumentNullException(nameof(paymentsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Выплата"</returns>
        public async Task<PaymentDto> Handle(UpdatePaymentRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Payment == null) throw new NullReferenceException(nameof(request.Payment));

            await CheckUpdatePaymentDtoAsync(request.Payment, cancellationToken);

            var payment = request.Payment.MapPayment();

            _paymentsService.ValidationEntity(payment);

            _dbContext.Payments.Update(payment);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return payment.MapPaymentDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Выплата"
        /// </summary>
        /// <param name="payment">DTO обновления "Выплата"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckUpdatePaymentDtoAsync(UpdatePaymentDto payment, CancellationToken cancellationToken)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));

            if (await _dbContext.Payments.AsNoTracking()
                .AnyAsync(rec => rec.Id == payment.Id, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня виплата в базі (id: {payment.Id})");

            if (await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == payment.EmployeeCardId, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня картка робітника в базі з {payment.EmployeeCardId}");
        }
    }
}
