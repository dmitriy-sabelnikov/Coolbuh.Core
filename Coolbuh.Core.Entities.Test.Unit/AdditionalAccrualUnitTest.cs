using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Дополнительные начисления"
    /// </summary>
    public class AdditionalAccrualUnitTest
    {
        /// <summary>
        /// Тестирование валидации - не указан работник
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutEmployeeTest()
        {
            // Arrange
            var entity = GetFakeAdditionalAccrual();
            entity.EmployeeCardId = 0;
            var service = new AdditionalAccrualsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Тестирование валидации - не указано подразделение
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutDepartmentTest()
        {
            // Arrange
            var entity = GetFakeAdditionalAccrual();
            entity.DepartmentId = 0;
            var service = new AdditionalAccrualsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Тестирование валидации - не указан тип дополнительного начисления
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutAdditionalAccrualTypeTest()
        {
            // Arrange
            var entity = GetFakeAdditionalAccrual();
            entity.AdditionalAccrualTypeId = 0;
            var service = new AdditionalAccrualsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Тестирование валидации - не указан отчетный период
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutAccountingPeriodTest()
        {
            // Arrange
            var entity = GetFakeAdditionalAccrual();
            entity.AccountingPeriod = DateTime.MinValue;
            var service = new AdditionalAccrualsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковое дополнительное начисление
        /// </summaПry>
        /// <returns>Фейковое дополнительное начисление</returns>
        private static AdditionalAccrual GetFakeAdditionalAccrual()
        {
            return new AdditionalAccrual()
            {
                Id = 1,
                EmployeeCardId = 1,
                DepartmentId = 1,
                AccountingPeriod = new DateTime(2020, 10, 1),
                AdditionalAccrualTypeId = 1,
                Sum = 10
            };
        }
    }
}
