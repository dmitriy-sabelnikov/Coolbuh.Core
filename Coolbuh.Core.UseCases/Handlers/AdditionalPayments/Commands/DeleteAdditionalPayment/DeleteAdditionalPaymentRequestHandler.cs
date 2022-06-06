using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.DeleteAdditionalPayment
{
    /// <summary>
    /// Обработчик команды "Удалить дополнительную выплату"
    /// </summary>
    public class DeleteAdditionalPaymentRequestHandler
        : IRequestHandler<DeleteAdditionalPaymentRequest, AdditionalPaymentDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteAdditionalPaymentRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Дополнительная выплата"</returns>
        public async Task<AdditionalPaymentDto> Handle(DeleteAdditionalPaymentRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AdditionalPayment == null) throw new NullReferenceException(nameof(request.AdditionalPayment));

            var additionalPayment =
                await GetAdditionalPaymentAsync(request.AdditionalPayment.Id, cancellationToken);

            _dbContext.AdditionalPayments.Remove(additionalPayment);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return additionalPayment.MapAdditionalPaymentDto();
        }

        /// <summary>
        /// Получить дополнительную выплату
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Дополнительная выплата</returns>
        private async Task<AdditionalPayment> GetAdditionalPaymentAsync(int id, CancellationToken cancellationToken)
        {
            var additionalPayment = await _dbContext.AdditionalPayments.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (additionalPayment == null)
                throw new NotFoundEntityUseCaseException($"Відсутня додаткова виплата в базі (id: {id})");

            return additionalPayment;
        }
    }
}
