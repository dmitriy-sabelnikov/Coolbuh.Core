using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.DeleteListOtherAllowance
{
    /// <summary>
    /// Обработчик команды "Удалить другую надбавку"
    /// </summary>
    public class DeleteListOtherAllowanceRequestHandler
        : IRequestHandler<DeleteListOtherAllowanceRequest, ListOtherAllowanceDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListOtherAllowanceRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Другие надбавки"</returns>
        public async Task<ListOtherAllowanceDto> Handle(DeleteListOtherAllowanceRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.OtherAllowance == null) throw new NullReferenceException(nameof(request.OtherAllowance));

            var otherAllowance = await GetListOtherAllowanceAsync(request.OtherAllowance.Id, cancellationToken);

            _dbContext.ListOtherAllowances.Remove(otherAllowance);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return otherAllowance.MapListOtherAllowanceDto();
        }

        /// <summary>
        /// Получить другие надбавки
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Другая надбавка</returns>
        private async Task<ListOtherAllowance> GetListOtherAllowanceAsync(int id, CancellationToken cancellationToken)
        {
            var otherAllowance = await _dbContext.ListOtherAllowances.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (otherAllowance == null)
                throw new NotFoundEntityUseCaseException($"Відсутня надбавка в базі (id: {id})");

            return otherAllowance;
        }
    }
}
