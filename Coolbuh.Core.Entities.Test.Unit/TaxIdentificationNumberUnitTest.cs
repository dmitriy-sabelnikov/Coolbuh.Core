using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Exceptions;
using System;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Идентификационный номер"
    /// </summary>
    public class TaxIdentificationNumberUnitTest
    {
        /// <summary>
        /// Валидация ИНН - пустой ИНН
        /// </summary>
        [Fact]
        public void ValidationTaxIdentificationNumberIfEmptyTest()
        {
            // Arrange
            var service = new TaxIdentificationNumberService();
            var taxIdentificationNumber = string.Empty;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(
                () => service.ValidationTaxIdentificationNumber(taxIdentificationNumber));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация ИНН - не верная длина ИНН
        /// </summary>
        [Fact]
        public void ValidationTaxIdentificationNumberIfWrongLengthTest()
        {
            // Arrange
            var service = new TaxIdentificationNumberService();
            var taxIdentificationNumber = "012345678";

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(
                () => service.ValidationTaxIdentificationNumber(taxIdentificationNumber));

            // Assert
            Assert.NotEmpty(result.Message);

        }

        /// <summary>
        /// Валидация ИНН - некорректные символы в ИНН
        /// </summary>
        [Fact]
        public void ValidationTaxIdentificationNumberIfExistsLetterTest()
        {
            // Arrange
            var service = new TaxIdentificationNumberService();
            var taxIdentificationNumber = "012345678W";

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(
                () => service.ValidationTaxIdentificationNumber(taxIdentificationNumber));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация ИНН - некорректный ИНН
        /// </summary>
        [Fact]
        public void ValidationTaxIdentificationNumberIfWrongTest()
        {
            // Arrange
            var service = new TaxIdentificationNumberService();
            var taxIdentificationNumber = "1012345678";

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(
                () => service.ValidationTaxIdentificationNumber(taxIdentificationNumber));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Тестирование вычисления даты рождения
        /// </summary>
        [Fact]
        public void GetBirthDateTest()
        {
            // Arrange
            var service = new TaxIdentificationNumberService();
            var taxIdentificationNumber = "2151309433";
            var birthDate = new DateTime(1958, 11, 25);

            // Act
            var resultBirthDate = service.GetBirthDate(taxIdentificationNumber);

            // Assert
            Assert.Equal(birthDate, resultBirthDate);
        }

        /// <summary>
        /// Тестирование вычисления пола
        /// </summary>
        [Fact]
        public void GetSexTest()
        {
            // Arrange
            var service = new TaxIdentificationNumberService();
            var taxIdentificationNumber = "2151309433";
            var sex = EmployeeCardSex.Male;

            // Act
            var resultSex = service.GetSex(taxIdentificationNumber);

            // Assert
            Assert.Equal(sex, resultSex);
        }
    }
}
