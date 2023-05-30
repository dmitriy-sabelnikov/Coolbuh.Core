using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using Coolbuh.Core.UseCases.Handlers.SickLists.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.SickLists.Commands.DeleteSickList
{
    /// <summary>
    /// Обработчик команды "Удалить больничный лист"
    /// </summary>
    public class DeleteSickListRequestHandler : IRequestHandler<DeleteSickListRequest, SickListDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteSickListRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Больничный лист"</returns>
        public async Task<SickListDto> Handle(DeleteSickListRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.SickList == null) throw new InvalidOperationException("request.SickList is null");

            var sickList = await GetSickListAsync(request.SickList.Id, cancellationToken);

            _dbContext.SickLists.Remove(sickList);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return sickList.MapSickListDto();
        }

        /// <summary>
        /// Получить больничный лист
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Больничный лист</returns>
        private async Task<SickList> GetSickListAsync(int id, CancellationToken cancellationToken)
        {
            var sickList = await _dbContext.SickLists
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (sickList == null)
                throw new NotFoundEntityUseCaseException($"Відсутній лікарняний в базі (id: {id})");

            return sickList;
        }
    }
}
