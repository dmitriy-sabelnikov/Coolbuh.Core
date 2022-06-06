using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Социальные льготы"
    /// </summary>
    public class ListSocialBenefitUnitTest
    {
        /// <summary>
        /// Валидация спецстажа - дата начала периода больше даты окончания
        /// </summary>
        [Fact]
        public void ValidateEntityPeriodBeginMoreThanperiodEndTest()
        {
            // Arrange
            var entity = GetFakeListSocialBenefit();
            entity.PeriodEnd = new DateTime(2022, 05, 01);
            entity.PeriodBegin = entity.PeriodEnd.Value.AddDays(1);
            var service = new ListSocialBenefitsService();

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация спецстажа - не указана сумма
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutSumTest()
        {
            // Arrange
            var entity = GetFakeListSocialBenefit();
            entity.Sum = 0;
            var service = new ListSocialBenefitsService();

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
            var entity = GetFakeListSocialBenefit();

            entity.Id = 1;
            entity.PeriodBegin = new DateTime(2022, 05, 01);
            entity.PeriodEnd = entity.PeriodBegin.Value.AddDays(1);

            var entities = new List<ListSocialBenefit>
            {
                new ListSocialBenefit
                {
                    Id = entity.Id + 1,
                    PeriodBegin = entity.PeriodBegin,
                    PeriodEnd = entity.PeriodEnd,
                    LimitSum = entity.LimitSum,
                    Sum = entity.Sum
                }
            };
            var service = new ListSocialBenefitsService();

            //Act
            var result = service.IsExistsPeriodIntersection(entity, entities);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Получить фейковую социальную льготу
        /// </summary>
        /// <returns>Фейковая социальная льгота</returns>
        private static ListSocialBenefit GetFakeListSocialBenefit()
        {
            return new ListSocialBenefit
            {
                Id = 1,
                PeriodBegin = new DateTime(2022, 05, 01),
                PeriodEnd = new DateTime(2022, 05, 01),
                Sum = 1,
                LimitSum = 1
            };
        }
    }
}
