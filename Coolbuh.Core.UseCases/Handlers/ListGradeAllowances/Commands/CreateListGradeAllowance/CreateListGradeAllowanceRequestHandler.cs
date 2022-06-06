using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.CreateListGradeAllowance
{
    /// <summary>
    /// Обработчик команды "Создать надбавку за классность"
    /// </summary>
    public class CreateListGradeAllowanceRequestHandler
        : IRequestHandler<CreateListGradeAllowanceRequest, ListGradeAllowanceDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListGradeAllowancesService _gradeAllowanceService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="gradeAllowanceService">Доменный сервис справочника "Надбавки за классность"</param>
        public CreateListGradeAllowanceRequestHandler(IDbContext dbContext,
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
        public async Task<ListGradeAllowanceDto> Handle(CreateListGradeAllowanceRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.GradeAllowance == null) throw new NullReferenceException(nameof(request.GradeAllowance));

            await CheckCreateListGradeAllowanceDtoAsync(request.GradeAllowance, cancellationToken);

            var gradeAllowance = request.GradeAllowance.MapListGradeAllowance();

            _gradeAllowanceService.ValidationEntity(gradeAllowance);

            await _dbContext.ListGradeAllowances.AddAsync(gradeAllowance, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return gradeAllowance.MapListGradeAllowanceDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Надбавки за классность"
        /// </summary>
        /// <param name="gradeAllowance">DTO создания "Надбавки за классность"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckCreateListGradeAllowanceDtoAsync(CreateListGradeAllowanceDto gradeAllowance,
            CancellationToken cancellationToken)
        {
            if (gradeAllowance == null) throw new ArgumentNullException(nameof(gradeAllowance));

            if (await _dbContext.ListGradeAllowances
                .AnyAsync(rec => rec.Code == gradeAllowance.Code, cancellationToken))
                throw new UseCaseException($"Дублікат коду {gradeAllowance.Code} в довіднику");
        }
    }
}
