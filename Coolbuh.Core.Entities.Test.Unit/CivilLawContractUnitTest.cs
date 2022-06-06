using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Договора ГПХ"
    /// </summary>
    public class CivilLawContractUnitTest
    {
        /// <summary>
        /// Валидация договора ГПХ - не указан работник
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutEmployeeTest()
        {
            // Arrange
            var service = new CivilLawContractsService();
            var entity = GetFakeCivilLawContract();
            entity.EmployeeCardId = 0;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация договора ГПХ - не указано подразделение
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutDepartmenTest()
        {
            // Arrange
            var service = new CivilLawContractsService();
            var entity = GetFakeCivilLawContract();
            entity.DepartmentId = 0;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация договора ГПХ - не отчетный период
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutAccountingPeriodTest()
        {
            // Arrange
            var service = new CivilLawContractsService();
            var entity = GetFakeCivilLawContract();
            entity.AccountingPeriod = DateTime.MinValue;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация договора ГПХ - не указан период, за который проводится начисление
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutAccrualPeriodTest()
        {
            // Arrange
            var service = new CivilLawContractsService();
            var entity = GetFakeCivilLawContract();
            entity.AccrualPeriod = DateTime.MinValue;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковый договор ГПХ
        /// </summary>
        /// <returns>Фейковый договор ГПХ</returns>
        private static CivilLawContract GetFakeCivilLawContract()
        {
            return new CivilLawContract()
            {
                Id = 1,
                EmployeeCardId = 1,
                DepartmentId = 1,
                AccountingPeriod = new DateTime(2022, 10, 1),
                AccrualPeriod = new DateTime(2022, 10, 1),
                Days = 1,
                Sum = 1
            };
        }
    }
}
