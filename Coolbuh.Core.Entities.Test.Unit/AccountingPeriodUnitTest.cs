using Coolbuh.Core.DomainServices.Implementation;
using System;
using System.Linq;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Отчетные периоды"
    /// </summary>
    public class AccountingPeriodUnitTest
    {
        /// <summary>
        /// Тестирование получения списка отчетных периодов без добавления элемента "Год" 
        /// </summary>
        [Fact]
        public void GetAccountingPeriodWithoutAddItemAllYearTest()
        {
            // Arrange
            var service = new AccountingPeriodsService();
            var periodStart = new DateTime(2021, 10, 01);
            var periodEnd = new DateTime(2021, 12, 01);
            var countMonth = (periodEnd.Year - periodStart.Year) * 12 + periodEnd.Month - periodStart.Month + 1;

            //Act
            var periods = service.GetAccountingPeriods(periodStart, periodEnd, false);

            //Assert            
            Assert.NotNull(periods);
            Assert.Equal(periods.Count(), countMonth);
            Assert.Contains(periods, period => period.Caption != string.Empty);
            Assert.Contains(periods, period =>
            {
                var compareDate = new DateTime(period.Year, period.Month, 1);

                return compareDate <= periodEnd && compareDate >= periodStart;
            });
        }

        /// <summary>
        /// Тестирование получения списка отчетных периодов с добавлением элемента "Год" 
        /// </summary>
        [Fact]
        public void GetAccountingPeriodWithAddItemAllYearTest()
        {
            // Arrange
            var service = new AccountingPeriodsService();
            var periodStart = new DateTime(2021, 10, 01);
            var periodEnd = new DateTime(2021, 12, 01);
            var countMonth = (periodEnd.Year - periodStart.Year) * 12 + periodEnd.Month - periodStart.Month + 1;
            var countRecord = (periodEnd.Year - periodStart.Year) + 1 + countMonth;

            //Act
            var periods = service.GetAccountingPeriods(periodStart, periodEnd, true);

            //Assert            
            Assert.NotNull(periods);
            Assert.Equal(periods.Count(), countRecord);
            Assert.Contains(periods, period => period.Caption != string.Empty);
            Assert.Contains(periods, period =>
            {
                if (period.Month == 0)
                {
                    return period.Year <= periodEnd.Year && period.Year >= periodStart.Year;
                }
                else
                {
                    var compareDate = new DateTime(period.Year, period.Month, 1);
                    return compareDate <= periodEnd && compareDate >= periodStart;
                }
            });
        }
    }
}
