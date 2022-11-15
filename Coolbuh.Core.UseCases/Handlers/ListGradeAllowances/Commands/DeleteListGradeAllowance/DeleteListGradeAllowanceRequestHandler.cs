using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.DeleteListGradeAllowance
{
    /// <summary>
    /// Обработчик команды "Удалить надбавку за классность"
    /// </summary>
    public class DeleteListGradeAllowanceRequestHandler
        : IRequestHandler<DeleteListGradeAllowanceRequest, ListGradeAllowanceDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListGradeAllowanceRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Надбавки за классность"</returns>
        public async Task<ListGradeAllowanceDto> Handle(DeleteListGradeAllowanceRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.GradeAllowance == null) throw new InvalidOperationException("request.GradeAllowance is null");

            var gradeAllowance = await GetListGradeAllowanceAsync(request.GradeAllowance.Id, cancellationToken);

            _dbContext.ListGradeAllowances.Remove(gradeAllowance);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return gradeAllowance.MapListGradeAllowanceDto();
        }

        /// <summary>
        /// Получить надбавку за классность
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Надбавка за классность</returns>
        private async Task<ListGradeAllowance> GetListGradeAllowanceAsync(int id, CancellationToken cancellationToken)
        {
            var gradeAllowance = await _dbContext.ListGradeAllowances.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (gradeAllowance == null)
                throw new NotFoundEntityUseCaseException($"Відсутня надбавка за класність в базі (id: {id})");

            return gradeAllowance;
        }
    }
}
