using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Заработные платы"
    /// </summary>
    public class SalaryUnitTest
    {
        /// <summary>
        /// Валидация зарплаты - не указан работник
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutEmployeeTest()
        {
            // Arrange
            var entity = GetFakeSalary();
            entity.EmployeeCardId = 0;
            var service = new SalariesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация зарплаты - не указано подразделение
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutDepartmentTest()
        {
            // Arrange
            var entity = GetFakeSalary();
            entity.DepartmentId = 0;
            var service = new SalariesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация зарплаты - не указан отчетный период 
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutAccountingPeriodTest()
        {
            // Arrange
            var entity = GetFakeSalary();
            entity.AccountingPeriod = DateTime.MinValue;
            var service = new SalariesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Тестирование расчета надбавки за пенсию
        /// </summary>
        [Fact]
        public void CalculatePensionAllowanceSumTest()
        {
            // Arrange
            var service = new SalariesService();
            var baseSum = 1000.0m;
            var percent = 50.0m;
            var allowanceSum = 500.0m;

            // Act
            var resultSum = service.CalculatePensionAllowanceSum(baseSum, percent);

            // Assert
            Assert.Equal(allowanceSum, resultSum);
        }

        /// <summary>
        /// Тестирование расчета надбавки за классность
        /// </summary>
        [Fact]
        public void CalculateGradeAllowanceSumTest()
        {
            // Arrange
            var service = new SalariesService();
            var baseSum = 1000.0m;
            var percent = 50.0m;
            var allowanceSum = 500.0m;

            // Act
            var resultSum = service.CalculateGradeAllowanceSum(baseSum, percent);

            // Assert
            Assert.Equal(allowanceSum, resultSum);
        }

        /// <summary>
        /// Тестирование расчета другой надбавки
        /// </summary>
        [Fact]
        public void CalculateOtherAllowanceSumTest()
        {
            // Arrange
            var service = new SalariesService();
            var baseSum = 1000.0m;
            var percent = 50.0m;
            var allowanceSum = 500.0m;

            // Act
            var resultSum = service.CalculateOtherAllowanceSum(baseSum, percent);

            // Assert
            Assert.Equal(allowanceSum, resultSum);
        }

        /// <summary>
        /// Тестирование расчета итоговой суммы зарплаты
        /// </summary>
        [Fact]
        public void CalculateSalaryResultSumTest()
        {
            // Arrange
            var service = new SalariesService();
            var sum = 1000.0m;
            var pensionAllowanceSum = 100.0m;
            var gradeAllowanceSum = 100.0m;
            var otherAllowanceSum = 100.0m;
            var totalSum = 1300.0m;

            // Act
            var resultSum = service.CalculateSalaryResultSum(sum, pensionAllowanceSum, gradeAllowanceSum, otherAllowanceSum);

            // Assert
            Assert.Equal(totalSum, resultSum);
        }

        /// <summary>
        /// Получить фейковую зарплату
        /// </summary>
        /// <returns>Фейковая зарплата</returns>
        private static Salary GetFakeSalary()
        {
            return new Salary
            {
                Id = 1,
                EmployeeCardId = 1,
                DepartmentId = 1,
                AccountingPeriod = new DateTime(2022, 05, 05),
                Days = 1,
                Hours = 1,
                BaseSum = 1,
                PensionAllowanceId = 1,
                PensionAllowanceSum = 1,
                GradeAllowanceId = 1,
                GradeAllowanceSum = 1,
                OtherAllowanceId = 1,
                OtherAllowanceSum = 1,
                TotalSum = 1
            };
        }
    }
}
