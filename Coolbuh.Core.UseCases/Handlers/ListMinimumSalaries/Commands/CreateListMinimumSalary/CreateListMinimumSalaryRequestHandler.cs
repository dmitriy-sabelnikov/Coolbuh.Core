using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.CreateListMinimumSalary
{
    /// <summary>
    /// Обработчик команды "Создать минимальную зарплату"
    /// </summary>
    public class CreateListMinimumSalaryRequestHandler
        : IRequestHandler<CreateListMinimumSalaryRequest, ListMinimumSalaryDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListMinimumSalariesService _minimumSalaryService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="minimumSalaryService">Доменный сервис справочника "Минимальные зарплаты"</param>
        public CreateListMinimumSalaryRequestHandler(IDbContext dbContext,
            IListMinimumSalariesService minimumSalaryService)
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
        public async Task<ListMinimumSalaryDto> Handle(CreateListMinimumSalaryRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.MinimumSalary == null) throw new InvalidOperationException("request.MinimumSalary is null");

            var minimumSalary = request.MinimumSalary.MapListMinimumSalary();
            _minimumSalaryService.ValidationEntity(minimumSalary);

            var minimumSalaries = await _dbContext.ListMinimumSalaries.AsNoTracking().ToListAsync(cancellationToken);
            if (_minimumSalaryService.IsExistsPeriodIntersection(minimumSalary, minimumSalaries))
                throw new UseCaseException("Період перетинається з існуючим");

            await _dbContext.ListMinimumSalaries.AddAsync(minimumSalary, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return minimumSalary.MapListMinimumSalaryDto();
        }
    }
}
