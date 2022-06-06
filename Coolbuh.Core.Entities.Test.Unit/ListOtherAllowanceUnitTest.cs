using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Другие надбавки"
    /// </summary>
    public class ListOtherAllowanceUnitTest
    {
        /// <summary>
        /// Валидация другой надбавки - не указан код
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutCodeTest()
        {
            // Arrange
            var entity = GetFakeListOtherAllowance();
            entity.Code = string.Empty;
            var service = new ListOtherAllowancesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация другой надбавки - превышение допустимой длины кода
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalCodeLengthTest()
        {
            // Arrange
            var entity = GetFakeListOtherAllowance();
            entity.Code = new string('A', ListOtherAllowanceConstants.CodeLength + 1);
            var service = new ListOtherAllowancesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация другой надбавки - не указано наименование
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutNameTest()
        {
            // Arrange
            var entity = GetFakeListOtherAllowance();
            entity.Name = string.Empty;
            var service = new ListOtherAllowancesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация другой надбавки - превышение допустимой длины наименования
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalNameLengthTest()
        {
            // Arrange
            var entity = GetFakeListOtherAllowance();
            entity.Name = new string('A', ListOtherAllowanceConstants.NameLength + 1);
            var service = new ListOtherAllowancesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация другой надбавки - не указан процент
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutPercentTest()
        {
            // Arrange
            var entity = GetFakeListOtherAllowance();
            entity.Percent = 0;
            var service = new ListOtherAllowancesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковую другую надбавку
        /// </summary>
        /// <returns>Фейковая другая надбавка</returns>
        private static ListOtherAllowance GetFakeListOtherAllowance()
        {
            return new ListOtherAllowance
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
