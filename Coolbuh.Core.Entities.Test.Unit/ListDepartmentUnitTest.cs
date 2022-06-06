using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Подразделения"
    /// </summary>
    public class ListDepartmentUnitTest
    {
        /// <summary>
        /// Валидация подразделения - не заполнен код
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutCodeTest()
        {
            // Arrange
            var service = new ListDepartmentsService();
            var entity = GetFakeListDepartment();
            entity.Code = string.Empty;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация подразделения - превышение допустимой длины кода
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalCodeLengthTest()
        {
            // Arrange
            var service = new ListDepartmentsService();
            var entity = GetFakeListDepartment();
            entity.Code = new string('A', ListDepartmentConstants.CodeLength + 1);

            //Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация подразделения - не заполнено наименование
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutNameTest()
        {
            // Arrange
            var service = new ListDepartmentsService();
            var entity = GetFakeListDepartment();
            entity.Name = string.Empty;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация подразделения - превышение допустимой длины наименования
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalNameLengthTest()
        {
            // Arrange
            var service = new ListDepartmentsService();
            var entity = GetFakeListDepartment();
            entity.Name = new string('A', ListDepartmentConstants.NameLength + 1);

            //Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковое подразделение
        /// </summary>
        /// <returns>Фейковое подразделение</returns>
        private static ListDepartment GetFakeListDepartment()
        {
            return new ListDepartment
            {
                Id = 1,
                Code = "1",
                Name = "1"
            };
        }
    }
}
