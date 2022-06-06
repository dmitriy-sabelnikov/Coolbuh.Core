using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Queries.GetAccountingPeriods;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.AccountingPeriods.Queries.GetAccountingPeriods
{
    /// <summary>
    /// Тестирование запроса "Получить список отчетных периодов"
    /// </summary>
    public class GetAccountingPeriodsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetAccountingPeriodsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeApplicationSettings = FakeDbRepository.GetFakeApplicationSettings();

            _fakeDbContext.Setup(set => set.ApplicationSettings).Returns(fakeApplicationSettings.Object);
        }

        /// <summary>
        /// Тестирование получения списка отчетных периодов
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAccountingPeriods()
        {
            // Arrange

            var fakeAccountingPeriodsService = new Mock<IAccountingPeriodsService>();
            var fakeAccountingPeriods = new List<AccountingPeriod>()
            {
                new AccountingPeriod
                {
                    Month = 1,
                    Year = 2022,
                    Caption = "Январь"
                }
            };

            fakeAccountingPeriodsService
                .Setup(service => service.GetAccountingPeriods(It.IsAny<DateTime>(), It.IsAny<DateTime>(), false))
                .Returns(fakeAccountingPeriods);

            var request = new GetAccountingPeriodsRequest
            {
                AddItemAllYear = false
            };

            var query = new GetAccountingPeriodsRequestHandler(_fakeDbContext.Object, fakeAccountingPeriodsService.Object);

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(fakeAccountingPeriods.Count, result.Count);
            Assert.Equal(fakeAccountingPeriods[0].Caption, result[0].Caption);
        }
    }
}
