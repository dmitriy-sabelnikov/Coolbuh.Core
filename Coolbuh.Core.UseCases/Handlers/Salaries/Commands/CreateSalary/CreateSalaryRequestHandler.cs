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

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Commands.CreateSalary
{
    /// <summary>
    /// Обработчик команды "Создать зарплату"
    /// </summary>
    public class CreateSalaryRequestHandler : IRequestHandler<CreateSalaryRequest, SalaryDto>
    {
        private readonly IDbContext _dbContext;
        private readonly ISalariesService _salariesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="salariesService">Доменный сервис "Заработные платы"</param>
        public CreateSalaryRequestHandler(IDbContext dbContext, ISalariesService salariesService)
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
        public async Task<SalaryDto> Handle(CreateSalaryRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Salary == null) throw new NullReferenceException(nameof(request.Salary));

            await CheckCreateSalaryDtoAsync(request.Salary, cancellationToken);

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

                salary.PensionAllowanceSum = allowance != null
                    ? _salariesService.CalculatePensionAllowanceSum(salary.BaseSum, allowance.Percent)
                    : 0;
            }

            //Расчет надбавки за классность
            if (salary.GradeAllowanceId != null)
            {
                var allowance = await _dbContext.ListGradeAllowances.AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.Id == salary.GradeAllowanceId, cancellationToken);

                if (allowance == null)
                    throw new NotFoundEntityUseCaseException(
                        $"Відсутня надбавка за класність в базі з id {salary.GradeAllowanceId}");

                salary.GradeAllowanceSum = allowance != null
                    ? _salariesService.CalculateGradeAllowanceSum(salary.BaseSum, allowance.Percent)
                    : 0;
            }

            //Расчет другой надбавки
            if (salary.OtherAllowanceId != null)
            {
                var allowance = await _dbContext.ListOtherAllowances.AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.Id == salary.OtherAllowanceId, cancellationToken);

                if (allowance == null)
                    throw new NotFoundEntityUseCaseException(
                        $"Відсутня інша надбавка в базі з id {salary.OtherAllowanceId}");

                salary.OtherAllowanceSum = allowance != null
                    ? _salariesService.CalculateOtherAllowanceSum(salary.BaseSum, allowance.Percent)
                    : 0;
            }

            //Расчет итоговой суммы
            salary.TotalSum = _salariesService.CalculateSalaryResultSum(salary.BaseSum,
                salary.PensionAllowanceSum, salary.GradeAllowanceSum, salary.OtherAllowanceSum);

            await _dbContext.Salaries.AddAsync(salary, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return salary.MapSalaryDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Зарплата"
        /// </summary>
        /// <param name="salary">DTO создания "Зарплата"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task CheckCreateSalaryDtoAsync(CreateSalaryDto salary, CancellationToken cancellationToken)
        {
            if (salary == null) throw new ArgumentNullException(nameof(salary));

            if (await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == salary.EmployeeCardId, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня картка робітника в базі з id {salary.EmployeeCardId}");

            if (await _dbContext.ListDepartments.AsNoTracking()
                .AnyAsync(rec => rec.Id == salary.DepartmentId, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутній підрозділ в базі з id {salary.DepartmentId}");
        }
    }
}
