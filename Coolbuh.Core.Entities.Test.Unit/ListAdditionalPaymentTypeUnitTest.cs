using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Типы дополнительных выплат"
    /// </summary>
    public class ListAdditionalPaymentTypeUnitTest
    {
        /// <summary>
        /// Валидация типа дополнительных выплат - не указан код
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutCodeTest()
        {
            // Arrange
            var service = new ListAdditionalPaymentTypesService();
            var entity = GetFakeListAdditionalPaymentType();
            entity.Code = string.Empty;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация типа дополнительных выплат - превышение допустимой длины кода
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalCodeLengthTest()
        {
            // Arrange
            var service = new ListAdditionalPaymentTypesService();
            var entity = GetFakeListAdditionalPaymentType();
            entity.Code = new string('A', ListAdditionalPaymentTypeConstants.CodeLength + 1);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация типа дополнительных выплат - не указано наименование
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutNameTest()
        {
            // Arrange
            var service = new ListAdditionalPaymentTypesService();
            var entity = GetFakeListAdditionalPaymentType();
            entity.Name = string.Empty;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация типа дополнительных выплат - превышение допустимой длины наименования
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalNameLengthTest()
        {
            // Arrange
            var service = new ListAdditionalPaymentTypesService();
            var entity = GetFakeListAdditionalPaymentType();
            entity.Name = new string('A', ListAdditionalPaymentTypeConstants.NameLength + 1);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковый тип дополнительных выплат
        /// </summary>
        /// <returns>Фейковый тип дополнительных выплат</returns>
        private static ListAdditionalPaymentType GetFakeListAdditionalPaymentType()
        {
            return new ListAdditionalPaymentType
            {
                Id = 1,
                Code = "1",
                Name = "1"
            };
        }
    }
}
