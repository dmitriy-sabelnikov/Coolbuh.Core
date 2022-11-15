using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using Coolbuh.Core.UseCases.Handlers.Salaries.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Commands.UpdateSalary
{
    /// <summary>
    /// Обработчик команды "Обновить зарплату"
    /// </summary>
    public class UpdateSalaryRequestHandler : IRequestHandler<UpdateSalaryRequest, SalaryDto>
    {
        private readonly IDbContext _dbContext;
        private readonly ISalariesService _salariesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="salariesService">Доменный сервис "Заработные платы"</param> 
        public UpdateSalaryRequestHandler(IDbContext dbContext, ISalariesService salariesService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _salariesService = salariesService ?? throw new ArgumentNullException(nameof(salariesService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Зарплата"</returns>
        public async Task<SalaryDto> Handle(UpdateSalaryRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Salary == null) throw new InvalidOperationException("request.Salary is null");

            await CheckSalaryAsync(request.Salary, cancellationToken);

            var salary = request.Salary.MapSalary();

            _salariesService.ValidationEntity(salary);

            //Расчет надбавки за пенсию
            if (salary.PensionAllowanceId != null)
            {
                var allowance = await _dbContext.ListPensionAllowances.AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.Id == salary.PensionAllowanceId, cancellationToken);

                if (allowance == null)
                    throw new NotFoundEntityUseCaseException(
                        $"Відсутня надбавка за пенсію в базі з id {salary.PensionAllowanceId}");

                salary.PensionAllowanceSum = _salariesService.CalculatePensionAllowanceSum(salary.BaseSum, allowance.Percent);
            }

            //Расчет надбавки за классность
            if (salary.GradeAllowanceId != null)
            {
                var allowance = await _dbContext.ListGradeAllowances.AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.Id == salary.GradeAllowanceId, cancellationToken);

                if (allowance == null)
                    throw new NotFoundEntityUseCaseException(
                        $"Відсутня надбавка за класність в базі з id {salary.GradeAllowanceId}");

                salary.GradeAllowanceSum = _salariesService.CalculateGradeAllowanceSum(salary.BaseSum, allowance.Percent);
            }

            //Расчет другой надбавки
            if (salary.OtherAllowanceId != null)
            {
                var allowance = await _dbContext.ListOtherAllowances.AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.Id == salary.OtherAllowanceId, cancellationToken);

                if (allowance == null)
                    throw new NotFoundEntityUseCaseException(
                        $"Відсутня інша надбавка в базі з id {salary.OtherAllowanceId}");

                salary.OtherAllowanceSum = _salariesService.CalculateOtherAllowanceSum(salary.BaseSum, allowance.Percent);
            }

            //Расчет итоговой суммы
            salary.TotalSum = _salariesService.CalculateSalaryResultSum(salary.BaseSum,
                salary.PensionAllowanceSum, salary.GradeAllowanceSum, salary.OtherAllowanceSum);

            _dbContext.Salaries.Update(salary);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return salary.MapSalaryDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Зарплата"
        /// </summary>
        /// <param name="salary">DTO обновления "Зарплата"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task CheckSalaryAsync(UpdateSalaryDto salary, CancellationToken cancellationToken)
        {
            if (salary == null) throw new ArgumentNullException(nameof(salary));

            if (!await _dbContext.Salaries.AsNoTracking()
                .AnyAsync(rec => rec.Id == salary.Id, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутня зарплата в базі з id {salary.Id}");

            if (!await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == salary.EmployeeCardId, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутня картка робітника в базі з id {salary.EmployeeCardId}");

            if (!await _dbContext.ListDepartments.AsNoTracking()
                .AnyAsync(rec => rec.Id == salary.DepartmentId, cancellationToken))
                throw new NotFoundEntityUseCaseException($"Відсутній підрозділ в базі з id {salary.DepartmentId}");
        }
    }
}
