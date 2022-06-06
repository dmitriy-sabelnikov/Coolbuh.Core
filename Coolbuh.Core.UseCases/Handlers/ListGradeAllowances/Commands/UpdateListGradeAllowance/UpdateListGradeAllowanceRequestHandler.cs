using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.UpdateListGradeAllowance
{
    /// <summary>
    /// Обработчик команды "Обновить надбавку за классность"
    /// </summary>
    public class UpdateListGradeAllowanceRequestHandler
        : IRequestHandler<UpdateListGradeAllowanceRequest, ListGradeAllowanceDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListGradeAllowancesService _gradeAllowanceService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="gradeAllowanceService">Доменный сервис справочника "Надбавки за классность"</param>
        public UpdateListGradeAllowanceRequestHandler(IDbContext dbContext,
            IListGradeAllowancesService gradeAllowanceService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _gradeAllowanceService = gradeAllowanceService ??
                                     throw new ArgumentNullException(nameof(gradeAllowanceService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Надбавки за классность"</returns>
        public async Task<ListGradeAllowanceDto> Handle(UpdateListGradeAllowanceRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.GradeAllowance == null) throw new NullReferenceException(nameof(request.GradeAllowance));

            await CheckUpdateListGradeAllowanceDtoAsync(request.GradeAllowance, cancellationToken);

            var gradeAllowance = request.GradeAllowance.MapListGradeAllowance();

            _gradeAllowanceService.ValidationEntity(gradeAllowance);

            _dbContext.ListGradeAllowances.Update(gradeAllowance);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return gradeAllowance.MapListGradeAllowanceDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Надбавки за классность"
        /// </summary>
        /// <param name="gradeAllowance">DTO обновления "Надбавки за классность"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckUpdateListGradeAllowanceDtoAsync(UpdateListGradeAllowanceDto gradeAllowance,
            CancellationToken cancellationToken)
        {
            if (gradeAllowance == null) throw new ArgumentNullException(nameof(gradeAllowance));

            //Code можно поменять
            var gradeAllowances = await _dbContext.ListGradeAllowances.AsNoTracking()
                .Where(rec => rec.Code == gradeAllowance.Code || rec.Id == gradeAllowance.Id)
                .ToListAsync(cancellationToken);

            if (gradeAllowances.Any(rec => rec.Id == gradeAllowance.Id) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня надбавка за класність в базі (id: {gradeAllowance.Id})");

            if (gradeAllowances.Any(rec => rec.Id != gradeAllowance.Id))
                throw new UseCaseException($"Дублікат коду {gradeAllowance.Code} в довіднику");
        }
    }
}
