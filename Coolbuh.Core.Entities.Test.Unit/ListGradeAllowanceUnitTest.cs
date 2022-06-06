using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Надбавка за классность"
    /// </summary>
    public class ListGradeAllowanceUnitTest
    {
        /// <summary>
        /// Валидация надбавки за классность - не заполнен код
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutCodeTest()
        {
            // Arrange
            var service = new ListGradeAllowancesService();
            var entity = GetFakeListGradeAllowance();
            entity.Code = string.Empty;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация надбавки за классность - превышение допустимой длины кода
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalCodeLengthTest()
        {
            // Arrange
            var service = new ListGradeAllowancesService();
            var entity = GetFakeListGradeAllowance();
            entity.Code = new string('A', ListGradeAllowanceConstants.CodeLength + 1);

            //Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация надбавки за классность - не заполнено наименование
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutNameTest()
        {
            // Arrange
            var service = new ListGradeAllowancesService();
            var entity = GetFakeListGradeAllowance();
            entity.Name = string.Empty;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация надбавки за классность - превышение допустимой длины наименования
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalNameLengthTest()
        {
            // Arrange
            var service = new ListGradeAllowancesService();
            var entity = GetFakeListGradeAllowance();
            entity.Name = new string('A', ListGradeAllowanceConstants.NameLength + 1);

            //Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация надбавки за классность - не заполнен процент
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutPercentTest()
        {
            // Arrange
            var service = new ListGradeAllowancesService();
            var entity = GetFakeListGradeAllowance();
            entity.Percent = 0;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковую надбавку за классность
        /// </summary>
        /// <returns>Фейковая надбавка за классность</returns>
        private static ListGradeAllowance GetFakeListGradeAllowance()
        {
            return new ListGradeAllowance
            {
                Id = 1,
                Code = "A",
                Name = "a",
                Percent = 10,
                DepartmentId = 1,
                Grade = 1,
                Flags = 0
            };
        }
    }
}
