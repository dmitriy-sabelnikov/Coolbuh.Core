using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Дополнительные выплаты"
    /// </summary>
    public class AdditionalPaymentUnitTest
    {
        /// <summary>
        /// Тестирование валидации - не указан работник
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutEmployeeTest()
        {
            // Arrange
            var service = new AdditionalPaymentsService();
            var entity = GetFakeAdditionalPayment();
            entity.EmployeeCardId = 0;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);

        }

        /// <summary>
        /// Тестирование валидации - не указан тип дополнительной выплаты
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutAdditionalPaymentTypeTest()
        {
            // Arrange
            var service = new AdditionalPaymentsService();
            var entity = GetFakeAdditionalPayment();
            entity.AdditionalPaymentTypeId = 0;

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
            var service = new AdditionalPaymentsService();
            var entity = GetFakeAdditionalPayment();
            entity.AccountingPeriod = DateTime.MinValue;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковую дополнительную выплату
        /// </summary>
        /// <returns>Фейковая дополнительная выплата</returns>
        private static AdditionalPayment GetFakeAdditionalPayment()
        {
            return new AdditionalPayment
            {
                Id = 1,
                EmployeeCardId = 1,
                AdditionalPaymentTypeId = 1,
                AccountingPeriod = new DateTime(2022, 05, 05),
                Sum = 1
            };
        }
    }
}
