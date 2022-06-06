using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Минимальные зарплаты"
    /// </summary>
    public class ListMinimumSalaryUnitTest
    {
        /// <summary>
        /// Валидация минимальной зарплаты - дата начала периода больше даты окончания
        /// </summary>
        [Fact]
        public void ValidateEntityPeriodBeginMoreThanPeriodEndTest()
        {
            // Arrange
            var service = new ListMinimumSalariesService();
            var entity = GetFakeListMinimumSalary();
            entity.PeriodEnd = new DateTime(2022, 05, 01);
            entity.PeriodBegin = entity.PeriodEnd.Value.AddDays(1);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация минимальной зарплаты - не заполнена сумма
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutSumTest()
        {
            // Arrange
            var service = new ListMinimumSalariesService();
            var entity = GetFakeListMinimumSalary();
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
            var entity = GetFakeListMinimumSalary();

            entity.Id = 1;
            entity.PeriodBegin = new DateTime(2022, 05, 01);
            entity.PeriodEnd = entity.PeriodBegin.Value.AddDays(1);

            var entities = new List<ListMinimumSalary>
            {
                new ListMinimumSalary
                {
                    Id = entity.Id + 1,
                    PeriodBegin = entity.PeriodBegin,
                    PeriodEnd = entity.PeriodEnd,
                    Sum = entity.Sum
                }
            };
            var service = new ListMinimumSalariesService();

            //Act
            var result = service.IsExistsPeriodIntersection(entity, entities);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Получить фейковую минимальную зарплату
        /// </summary>
        /// <returns>Фейковая минимальная зарплата</returns>
        private static ListMinimumSalary GetFakeListMinimumSalary()
        {
            return new ListMinimumSalary
            {
                Id = 1,
                PeriodBegin = new DateTime(2022, 05, 01),
                PeriodEnd = new DateTime(2022, 05, 10),
                Sum = 1
            };
        }
    }
}
