using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using Moq;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Администрации"
    /// </summary>
    public class ListAdministrationUnitTest
    {
        /// <summary>
        /// Валидация администрации - не заполнено ФИО
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutFullNameTest()
        {
            // Arrange
            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new ListAdministrationsService(mockTINService.Object);
            var entity = GetFakeListAdministration();
            entity.FullName = string.Empty;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация администрации - превышение допустимой длины ФИО
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalFullNameLengthTest()
        {
            // Arrange
            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new ListAdministrationsService(mockTINService.Object);
            var entity = GetFakeListAdministration();
            entity.FullName = new string('A', ListAdministrationConstants.FullNameLength + 1);

            //Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация администрации - не заполнен телефон
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutTelephoneNumberTest()
        {
            // Arrange
            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new ListAdministrationsService(mockTINService.Object);
            var entity = GetFakeListAdministration();
            entity.TelephoneNumber = string.Empty;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация администрации - превышение допустимой длины телефона
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalTelephoneNumberLengthTest()
        {
            // Arrange
            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new ListAdministrationsService(mockTINService.Object);
            var entity = GetFakeListAdministration();
            entity.TelephoneNumber = new string('A', ListAdministrationConstants.TelephoneNumberLength + 1);

            //Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация администрации - не заполнена должность
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutPositionTest()
        {
            // Arrange
            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new ListAdministrationsService(mockTINService.Object);
            var entity = GetFakeListAdministration();
            entity.PositionId = 0;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковую администрацию
        /// </summary>
        /// <returns>Фейковая администрация</returns>
        private static ListAdministration GetFakeListAdministration()
        {
            return new ListAdministration
            {
                Id = 1,
                TaxIdentificationNumber = "1421406487",
                FullName = "Ivanov",
                PositionId = 1,
                TelephoneNumber = "203-89-09"
            };
        }
    }
}
