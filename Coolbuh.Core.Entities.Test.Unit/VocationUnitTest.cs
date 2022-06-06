using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Отпуска"
    /// </summary>
    public class VocationUnitTest
    {
        /// <summary>
        /// Валидация отпуска - не указан работник
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutEmployeeTest()
        {
            // Arrange
            var entity = GetFakeVocation();
            entity.EmployeeCardId = 0;
            var service = new VocationsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);

        }

        /// <summary>
        /// Валидация отпуска - не указано подразделение
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutDepartmentTest()
        {
            // Arrange
            var entity = GetFakeVocation();
            entity.DepartmentId = 0;
            var service = new VocationsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация отпуска - не указан отчетный период
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutAccountingPeriodTest()
        {
            // Arrange
            var entity = GetFakeVocation();
            entity.AccountingPeriod = DateTime.MinValue;
            var service = new VocationsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация отпуска - не указан период, за который проводится начисление
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutAccrualPeriodTest()
        {
            // Arrange
            var entity = GetFakeVocation();
            entity.AccrualPeriod = DateTime.MinValue;
            var service = new VocationsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковый отпуск
        /// </summary>
        /// <returns>Фейковый отпуск</returns>
        private static Vocation GetFakeVocation()
        {
            return new Vocation
            {
                Id = 1,
                EmployeeCardId = 1,
                DepartmentId = 1,
                AccountingPeriod = new DateTime(2022, 05, 05),
                AccrualPeriod = new DateTime(2022, 05, 05),
                Days = 1,
                Sum = 1
            };
        }
    }
}
