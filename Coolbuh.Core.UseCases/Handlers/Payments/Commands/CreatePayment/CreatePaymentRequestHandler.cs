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

namespace Coolbuh.Core.UseCases.Handlers.Payments.Commands.CreatePayment
{
    /// <summary>
    /// Обработчик команды "Создать выплату"
    /// </summary>
    public class CreatePaymentRequestHandler : IRequestHandler<CreatePaymentRequest, PaymentDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IPaymentsService _paymentsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="paymentsService">Доменный сервис "Выплаты"</param>
        public CreatePaymentRequestHandler(IDbContext dbContext, IPaymentsService paymentsService)
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
        public async Task<PaymentDto> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Payment == null) throw new NullReferenceException(nameof(request.Payment));

            await CheckCreatePaymentDtoAsync(request.Payment, cancellationToken);

            var payment = request.Payment.MapPayment();

            _paymentsService.ValidationEntity(payment);

            await _dbContext.Payments.AddAsync(payment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return payment.MapPaymentDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Выплата"
        /// </summary>
        /// <param name="payment">DTO создания "Выплата"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckCreatePaymentDtoAsync(CreatePaymentDto payment, CancellationToken cancellationToken)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));

            if (await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == payment.EmployeeCardId, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня картка робітника в базі з {payment.EmployeeCardId}");
        }
    }
}
