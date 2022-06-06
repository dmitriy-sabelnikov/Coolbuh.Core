using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Спецстажи"
    /// </summary>
    public class ListSpecialSeniorityUnitTest
    {
        /// <summary>
        /// Валидация спецстажа - не указан код
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutCodeTest()
        {
            // Arrange
            var entity = GetFakeListSpecialSeniority();
            entity.Code = string.Empty;
            var service = new ListSpecialSenioritiesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация спецстажа - превышение допустимой длины кода
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalCodeLengthTest()
        {
            // Arrange
            var entity = GetFakeListSpecialSeniority();
            entity.Code = new string('A', ListSpecialSeniorityConstants.CodeLength + 1);
            var service = new ListSpecialSenioritiesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация спецстажа - не указан код основания
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutReasonCodeTest()
        {
            // Arrange
            var entity = GetFakeListSpecialSeniority();
            entity.ReasonCode = string.Empty;
            var service = new ListSpecialSenioritiesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация спецстажа - превышение допустимой длины кода основания
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalReasonCodeLengthTest()
        {
            // Arrange
            var entity = GetFakeListSpecialSeniority();
            entity.ReasonCode = new string('A', ListSpecialSeniorityConstants.ReasonCodeLength + 1);
            var service = new ListSpecialSenioritiesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация спецстажа - не указано наименование
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutNameTest()
        {
            // Arrange
            var entity = GetFakeListSpecialSeniority();
            entity.Name = string.Empty;
            var service = new ListSpecialSenioritiesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация спецстажа - превышение допустимой длины кода основания
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalNameLengthTest()
        {
            // Arrange
            var entity = GetFakeListSpecialSeniority();
            entity.Name = new string('A', ListSpecialSeniorityConstants.NameLength + 1);
            var service = new ListSpecialSenioritiesService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковый спецстаж
        /// </summary>
        /// <returns>Фейковый спецстаж</returns>
        private static ListSpecialSeniority GetFakeListSpecialSeniority()
        {
            return new ListSpecialSeniority
            {
                Id = 1,
                Code = "1",
                ReasonCode = "1",
                Name = "1"
            };
        }
    }
}
