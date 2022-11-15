using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.DeleteListAdditionalPaymentType
{
    /// <summary>
    /// Обработчик команды "Удалить тип дополнительных выплат"
    /// </summary>
    public class DeleteListAdditionalPaymentTypeRequestHandler
        : IRequestHandler<DeleteListAdditionalPaymentTypeRequest, ListAdditionalPaymentTypeDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListAdditionalPaymentTypeRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Типы дополнительных выплат"</returns>
        public async Task<ListAdditionalPaymentTypeDto> Handle(DeleteListAdditionalPaymentTypeRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AdditionalPaymentType == null)
                throw new InvalidOperationException("request.AdditionalPaymentType is null");

            var additionalPaymentType =
                await GetListAdditionalPaymentTypeAsync(request.AdditionalPaymentType.Id, cancellationToken);

            _dbContext.ListAdditionalPaymentTypes.Remove(additionalPaymentType);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return additionalPaymentType.MapListAdditionalPaymentTypeDto();
        }

        /// <summary>
        /// Получить тип дополнительных выплат
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Тип дополнительных выплат</returns>
        private async Task<ListAdditionalPaymentType> GetListAdditionalPaymentTypeAsync(int id,
            CancellationToken cancellationToken)
        {
            var additionalPaymentType = await _dbContext.ListAdditionalPaymentTypes.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (additionalPaymentType == null)
                throw new NotFoundEntityUseCaseException($"Відсутній тип додаткових виплат в базі (id: {id})");

            return additionalPaymentType;
        }
    }
}
