using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Прожиточные минимумы"
    /// </summary>
    public class ListLivingWageUnitTest
    {
        /// <summary>
        /// Валидация прожиточного минимума - дата начала периода больше даты окончания
        /// </summary>
        [Fact]
        public void ValidateEntityPeriodBeginMoreThanPeriodEndTest()
        {
            // Arrange
            var service = new ListLivingWagesService();
            var entity = GetFakeListLivingWage();
            entity.PeriodEnd = new DateTime(2022, 05, 01);
            entity.PeriodBegin = entity.PeriodEnd.Value.AddDays(1);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация прожиточного минимума - не заполнена сумма
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutSumTest()
        {
            // Arrange
            var service = new ListLivingWagesService();
            var entity = GetFakeListLivingWage();
            entity.Sum = 0;

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Тест поиска пересекающихся периодов
        /// </summary>
        [Fact]
        public void ExistsPeriodIntersectionTest()
        {
            // Arrange
            var entity = GetFakeListLivingWage();

            entity.Id = 1;
            entity.PeriodBegin = new DateTime(2022, 05, 01);
            entity.PeriodEnd = entity.PeriodBegin.Value.AddDays(1);

            var entities = new List<ListLivingWage>
            {
                new ListLivingWage
                {
                    Id = entity.Id + 1,
                    PeriodBegin = entity.PeriodBegin,
                    PeriodEnd = entity.PeriodEnd,
                    Sum = entity.Sum
                }
            };
            var service = new ListLivingWagesService();

            //Act
            var result = service.IsExistsPeriodIntersection(entity, entities);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Получить фейковый прожиточный минимум
        /// </summary>
        /// <returns>Фейковый прожиточный минимум</returns>
        private static ListLivingWage GetFakeListLivingWage()
        {
            return new ListLivingWage
            {
                Id = 1,
                PeriodBegin = new DateTime(2022, 05, 01),
                PeriodEnd = new DateTime(2022, 05, 10),
                Sum = 10
            };
        }
    }
}
