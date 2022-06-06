using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Каталог объединенной ведомости"
    /// </summary>
    public class ConsolidateReportUnitTest
    {
        /// <summary>
        /// Валидация каталога объединенной ведомости - не верный квартал
        /// </summary>
        [Fact]
        public void ValidateEntityWrongQuarterTest()
        {
            // Arrange
            var service = new ConsolidateReportsService();
            var entity = GetFakeConsolidateReportCatalog();
            entity.Quarter = 0;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация каталога объединенной ведомости - не заполнен год
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutYearTest()
        {
            // Arrange
            var service = new ConsolidateReportsService();
            var entity = GetFakeConsolidateReportCatalog();
            entity.Year = 0;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация каталога объединенной ведомости - не заполнен номер
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutNumberTest()
        {
            // Arrange
            var service = new ConsolidateReportsService();
            var entity = GetFakeConsolidateReportCatalog();
            entity.Number = 0;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация каталога объединенной ведомости - не заполнено наименование
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutNameTest()
        {
            // Arrange
            var service = new ConsolidateReportsService();
            var entity = GetFakeConsolidateReportCatalog();
            entity.Name = string.Empty;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковый каталог объединенной ведомости
        /// </summary>
        /// <returns>Фейковый каталог объединенной ведомости</returns>
        private static ConsolidateReportCatalog GetFakeConsolidateReportCatalog()
        {
            return new ConsolidateReportCatalog
            {
                Id = 1,
                Quarter = 1,
                Year = 1,
                Number = 1,
                Name = "1",
                CalculateDate = new DateTime(2022, 05, 01),
                Flags = 0
            };
        }
    }
}
