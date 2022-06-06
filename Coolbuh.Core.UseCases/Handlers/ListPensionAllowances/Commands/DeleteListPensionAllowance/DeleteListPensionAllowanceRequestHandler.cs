using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.DeleteListPensionAllowance
{
    /// <summary>
    /// Обработчик команды "Удалить надбавку за пенсию"
    /// </summary>
    public class DeleteListPensionAllowanceRequestHandler
        : IRequestHandler<DeleteListPensionAllowanceRequest, ListPensionAllowanceDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListPensionAllowanceRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Надбавки за пенсию"</returns>
        public async Task<ListPensionAllowanceDto> Handle(DeleteListPensionAllowanceRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.PensionAllowance == null) throw new NullReferenceException(nameof(request.PensionAllowance));

            var pensionAllowance =
                await GetListPensionAllowanceAsync(request.PensionAllowance.Id, cancellationToken);

            _dbContext.ListPensionAllowances.Remove(pensionAllowance);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return pensionAllowance.MapListPensionAllowanceDto();
        }

        /// <summary>
        /// Получить надбавку за пенсию
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Надбавка за пенсию</returns>
        private async Task<ListPensionAllowance> GetListPensionAllowanceAsync(int id,
            CancellationToken cancellationToken)
        {
            var pensionAllowance = await _dbContext.ListPensionAllowances.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (pensionAllowance == null)
                throw new NotFoundEntityUseCaseException($"Відсутня пенсійна надбавка в базі (id: {id})");

            return pensionAllowance;
        }
    }
}
