using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Queries.GetConsolidateReportCatalogs;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ConsolidateReports.Queries.GetConsolidateReportCatalogs
{
    /// <summary>
    /// Тестирование запроса "Получить список каталогов объединенной ведомости"
    /// </summary>
    public class GetConsolidateReportCatalogsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetConsolidateReportCatalogsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeConsolidateReportCatalogs = FakeDbRepository.GetFakeConsolidateReportCatalogs();

            _fakeDbContext.Setup(set => set.ConsolidateReportCatalogs).Returns(fakeConsolidateReportCatalogs.Object);
        }

        /// <summary>
        /// Тестирование получения списка каталогов объединенной ведомости"
        /// </summary>
        [Fact]
        public async Task GetConsolidateReportCatalogsTest()
        {
            // Arrange
            var query = new GetConsolidateReportCatalogsRequestHandler(_fakeDbContext.Object);
            var request = new GetConsolidateReportCatalogsRequest();
            var count = _fakeDbContext.Object.ConsolidateReportCatalogs.Count();
            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
