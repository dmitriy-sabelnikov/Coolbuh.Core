using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.DeleteListAdditionalAccrualType
{
    /// <summary>
    /// Обработчик команды "Удалить тип дополнительных начислений"
    /// </summary>
    public class
        DeleteListAdditionalAccrualTypeRequestHandler
            : IRequestHandler<DeleteListAdditionalAccrualTypeRequest, ListAdditionalAccrualTypeDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListAdditionalAccrualTypeRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Типы дополнительных начислений"</returns>
        public async Task<ListAdditionalAccrualTypeDto> Handle(DeleteListAdditionalAccrualTypeRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AdditionalAccrualType == null)
                throw new InvalidOperationException("request.AdditionalAccrualType is null");

            var additionalAccrualType =
                await GetListAdditionalAccrualTypeAsync(request.AdditionalAccrualType.Id,
                    cancellationToken);

            _dbContext.ListAdditionalAccrualTypes.Remove(additionalAccrualType);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return additionalAccrualType.MapListAdditionalAccrualTypeDto();
        }

        /// <summary>
        /// Получить тип дополнительных начислений
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Тип дополнительных начислений</returns>
        private async Task<ListAdditionalAccrualType> GetListAdditionalAccrualTypeAsync(int id,
            CancellationToken cancellationToken)
        {
            var additionalAccrualType = await _dbContext.ListAdditionalAccrualTypes
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (additionalAccrualType == null)
                throw new NotFoundEntityUseCaseException($"Відсутній тип додаткових нарахувань в базі (id: {id})");

            return additionalAccrualType;
        }
    }
}
