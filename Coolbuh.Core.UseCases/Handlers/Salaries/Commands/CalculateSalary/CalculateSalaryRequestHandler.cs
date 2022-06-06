using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Commands.CalculateSalary
{
    /// <summary>
    /// Обработчик команды "Рассчитать зарплату"
    /// </summary>
    public class CalculateSalaryRequestHandler : IRequestHandler<CalculateSalaryRequest, CalculatedSalaryDto>
    {
        private readonly IDbContext _dbContext;
        private readonly ISalariesService _salariesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CalculateSalaryRequestHandler(IDbContext dbContext, ISalariesService salariesService)
        {
            _dbContext = dbContext;
            _salariesService = salariesService;
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Рассчитанная зарплата"</returns>
        public async Task<CalculatedSalaryDto> Handle(CalculateSalaryRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var result = new CalculatedSalaryDto()
            {
                BaseSum = request.Salary.BaseSum
            };

            if (request.Salary.PensionAllowanceId != null)
            {
                var allowance = await _dbContext.ListPensionAllowances.AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.Id == request.Salary.PensionAllowanceId, cancellationToken);

                if (allowance == null)
                    throw new NotFoundEntityUseCaseException(
                        $"Відсутня надбавка пенсіонеру в базі з id {request.Salary.PensionAllowanceId}");

                result.PensionAllowanceSum = _salariesService.CalculatePensionAllowanceSum(request.Salary.BaseSum, allowance.Percent);
            }

            if (request.Salary.GradeAllowanceId != null)
            {
                var allowance = await _dbContext.ListGradeAllowances.AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.Id == request.Salary.GradeAllowanceId, cancellationToken);

                if (allowance == null)
                    throw new NotFoundEntityUseCaseException(
                        $"Відсутня надбавка за класність в базі з id {request.Salary.GradeAllowanceId}");

                result.GradeAllowanceSum = _salariesService.CalculateGradeAllowanceSum(request.Salary.BaseSum, allowance.Percent);
            }

            if (request.Salary.OtherAllowanceId != null)
            {
                var allowance = await _dbContext.ListOtherAllowances.AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.Id == request.Salary.OtherAllowanceId, cancellationToken);

                if (allowance == null)
                    throw new NotFoundEntityUseCaseException($"Відсутня інша надбавка в базі з id {request.Salary.OtherAllowanceId}");

                result.OtherAllowanceSum = _salariesService.CalculateOtherAllowanceSum(request.Salary.BaseSum, allowance.Percent);
            }

            result.TotalSum = _salariesService.CalculateSalaryResultSum(
                result.BaseSum, result.PensionAllowanceSum, result.GradeAllowanceSum, result.OtherAllowanceSum);

            return result;
        }
    }
}
