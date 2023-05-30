using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using Coolbuh.Core.UseCases.Handlers.Payments.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Commands.DeletePayment
{
    /// <summary>
    /// Обработчик команды "Удалить выплату"
    /// </summary>
    public class DeletePaymentRequestHandler : IRequestHandler<DeletePaymentRequest, PaymentDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeletePaymentRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Выплата"</returns>
        public async Task<PaymentDto> Handle(DeletePaymentRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Payment == null) throw new InvalidOperationException("request.Payment is null");

            var payment = await GetPaymentAsync(request.Payment.Id, cancellationToken);

            _dbContext.Payments.Remove(payment);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return payment.MapPaymentDto();
        }

        /// <summary>
        /// Получить выплату
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Выплата</returns>
        private async Task<Payment> GetPaymentAsync(int id, CancellationToken cancellationToken)
        {
            var payment = await _dbContext.Payments
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (payment == null)
                throw new NotFoundEntityUseCaseException($"Відсутня виплата в базі (id: {id})");

            return payment;
        }
    }
}
