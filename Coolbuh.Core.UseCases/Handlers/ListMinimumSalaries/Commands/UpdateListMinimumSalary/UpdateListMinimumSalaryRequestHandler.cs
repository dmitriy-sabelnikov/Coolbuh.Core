using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.UpdateListMinimumSalary
{
    /// <summary>
    /// Обработчик команды "Обновить минимальную зарплату"
    /// </summary>
    public class UpdateListMinimumSalaryRequestHandler
        : IRequestHandler<UpdateListMinimumSalaryRequest, ListMinimumSalaryDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListMinimumSalariesService _minimumSalaryService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="minimumSalaryService">Доменный сервис справочника "Минимальные зарплаты"</param>
        public UpdateListMinimumSalaryRequestHandler(IDbContext dbContext, IListMinimumSalariesService minimumSalaryService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _minimumSalaryService = minimumSalaryService ??
                                    throw new ArgumentNullException(nameof(minimumSalaryService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Минимальные зарплаты"</returns>
        public async Task<ListMinimumSalaryDto> Handle(UpdateListMinimumSalaryRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.MinimumSalary == null) throw new InvalidOperationException("request.MinimumSalary is null");


            var minimumSalary = request.MinimumSalary.MapListMinimumSalary();
            var minimumSalaries = await _dbContext.ListMinimumSalaries.AsNoTracking().ToListAsync(cancellationToken);

            if (!minimumSalaries.Any(rec => rec.Id == minimumSalary.Id))
                throw new NotFoundEntityUseCaseException($"Відсутня мінімальна зарплата в базі (id: {minimumSalary.Id})");

            _minimumSalaryService.ValidationEntity(minimumSalary);

            if (_minimumSalaryService.IsExistsPeriodIntersection(minimumSalary, minimumSalaries))
                throw new UseCaseException("Період перетинається з існуючим");

            _dbContext.ListMinimumSalaries.Update(minimumSalary);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return minimumSalary.MapListMinimumSalaryDto();
        }
    }
}
