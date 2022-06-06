using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Выплаты"
    /// </summary>
    public class PaymentUnitTest
    {
        /// <summary>
        /// Валидация выплаты - не указан работник
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutEmployeeTest()
        {
            // Arrange
            var entity = GetFakePayment();
            entity.EmployeeCardId = 0;
            var service = new PaymentsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация выплаты - не указан работник
        /// </summary>d
        [Fact]
        public void ValidateEntityWithoutAccountingPeriodTest()
        {
            // Arrange
            var entity = GetFakePayment();
            entity.AccountingPeriod = DateTime.MinValue;
            var service = new PaymentsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковую выплату
        /// </summary>
        /// <returns>Фейковая выплата</returns>
        private static Payment GetFakePayment()
        {
            return new Payment
            {
                Id = 1,
                EmployeeCardId = 1,
                AccountingPeriod = new DateTime(2022, 05, 05),
                Sum = 1
            };
        }
    }
}
