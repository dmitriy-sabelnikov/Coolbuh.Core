using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Больничный лист"
    /// </summary>
    public class SickListUnitTest
    {
        /// <summary>
        /// Валидация больничного листа - не указан работник
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutEmployeeTest()
        {
            // Arrange
            var entity = GetFakeSickList();
            entity.EmployeeCardId = 0;
            var service = new SickListsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация больничного листа - не указано подразделение
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutDepartmentTest()
        {
            // Arrange
            var entity = GetFakeSickList();
            entity.DepartmentId = 0;
            var service = new SickListsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация больничного листа - не указан отчетный период
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutAccountingPeriodTest()
        {
            // Arrange
            var entity = GetFakeSickList();
            entity.AccountingPeriod = DateTime.MinValue;
            var service = new SickListsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация больничного листа - не указан период, за который проводится начисление
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutAccrualPeriodTest()
        {
            // Arrange
            var entity = GetFakeSickList();
            entity.AccrualPeriod = DateTime.MinValue;
            var service = new SickListsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковый больничный лист
        /// </summary>
        /// <returns>Фейковый больничный лист</returns>
        private static SickList GetFakeSickList()
        {
            return new SickList
            {
                Id = 1,
                EmployeeCardId = 1,
                DepartmentId = 1,
                AccountingPeriod = new DateTime(2022, 05, 05),
                AccrualPeriod = new DateTime(2022, 05, 05),
                EnterpriseDays = 1,
                EnterpriseSum = 1,
                SocialInsuranceDays = 1,
                SocialInsuranceSum = 1
            };
        }
    }
}
