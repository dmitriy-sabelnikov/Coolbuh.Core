using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.DeleteListLivingWage
{
    /// <summary>
    /// Обработчик команды "Удалить прожиточный минимум"
    /// </summary>
    public class DeleteListLivingWageRequestHandler
        : IRequestHandler<DeleteListLivingWageRequest, ListLivingWageDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListLivingWageRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Прожиточный минимум"</returns>
        public async Task<ListLivingWageDto> Handle(DeleteListLivingWageRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.LivingWage == null) throw new NullReferenceException(nameof(request.LivingWage));

            var livingWage = await GetListLivingWageAsync(request.LivingWage.Id, cancellationToken);

            _dbContext.ListLivingWages.Remove(livingWage);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return livingWage.MapListLivingWageDto();
        }

        /// <summary>
        /// Получить прожиточный минимум
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Прожиточный минимум</returns>
        private async Task<ListLivingWage> GetListLivingWageAsync(int id, CancellationToken cancellationToken)
        {
            var livingWage = await _dbContext.ListLivingWages.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (livingWage == null)
                throw new NotFoundEntityUseCaseException($"Відсутній прожитковий мінімум в базі (id: {id})");

            return livingWage;
        }
    }
}
