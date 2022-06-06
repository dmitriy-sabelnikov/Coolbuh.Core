using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Надбавки за пенсию"
    /// </summary>
    public class ListPensionAllowanceUnitTest
    {
        /// <summary>
        /// Валидация надбавки за пенсию - не указан код
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutCodeTest()
        {
            // Arrange
            var entity = GetFakeListPensionAllowance();
            entity.Code = string.Empty;
            var service = new ListPensionAllowancesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация надбавки за пенсию - превышение допустимой длины кода
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalCodeLengthTest()
        {
            // Arrange
            var entity = GetFakeListPensionAllowance();
            entity.Code = new string('A', ListPensionAllowanceConstants.CodeLength + 1);
            var service = new ListPensionAllowancesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация надбавки за пенсию - не указано наименование
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutNameTest()
        {
            // Arrange
            var entity = GetFakeListPensionAllowance();
            entity.Name = string.Empty;
            var service = new ListPensionAllowancesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация надбавки за пенсию - превышение допустимой длины наименования
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalNameLengthTest()
        {
            // Arrange
            var entity = GetFakeListPensionAllowance();
            entity.Name = new string('A', ListPensionAllowanceConstants.NameLength + 1);
            var service = new ListPensionAllowancesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация надбавки за пенсию - не указан процент
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutPercentTest()
        {
            // Arrange
            var entity = GetFakeListPensionAllowance();
            entity.Percent = 0;
            var service = new ListPensionAllowancesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковую надбавку за пенсию
        /// </summary>
        /// <returns>Фейковая надбавка за пенсию</returns>
        private static ListPensionAllowance GetFakeListPensionAllowance()
        {
            return new ListPensionAllowance
            {
                Id = 1,
                Code = "1",
                Name = "1",
                Percent = 1,
                Flags = 0
            };
        }
    }
}
