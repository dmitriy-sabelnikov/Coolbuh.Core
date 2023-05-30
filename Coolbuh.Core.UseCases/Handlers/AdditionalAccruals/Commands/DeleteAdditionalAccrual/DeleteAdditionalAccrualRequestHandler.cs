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

namespace Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.DeleteAdditionalAccrual
{
    /// <summary>
    /// Обработчик команды "Удалить дополнительное начисление"
    /// </summary>
    public class DeleteAdditionalAccrualRequestHandler
        : IRequestHandler<DeleteAdditionalAccrualRequest, AdditionalAccrualDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteAdditionalAccrualRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Дополнительное начисление"</returns>
        public async Task<AdditionalAccrualDto> Handle(DeleteAdditionalAccrualRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AdditionalAccrual == null) throw new InvalidOperationException("request.AdditionalAccrual is null");

            var additionalAccrual = await GetAdditionalAccrual(request.AdditionalAccrual.Id, cancellationToken);

            _dbContext.AdditionalAccruals.Remove(additionalAccrual);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return additionalAccrual.MapAdditionalAccrualDto();
        }

        /// <summary>
        /// Получить дополнительное начисление
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Дополнительное начисление</returns>
        private async Task<AdditionalAccrual> GetAdditionalAccrual(int id, CancellationToken cancellationToken)
        {
            var additionalAccrual = await _dbContext.AdditionalAccruals
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (additionalAccrual == null)
                throw new NotFoundEntityUseCaseException($"Відсутнє додаткове нарахування в базі з id: {id}");

            return additionalAccrual;
        }
    }
}
