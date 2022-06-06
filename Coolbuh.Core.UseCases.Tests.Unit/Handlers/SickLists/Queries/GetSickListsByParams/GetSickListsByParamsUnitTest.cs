using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.SickLists.Queries.GetSickListsByParams;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.SickLists.Queries.GetSickListsByParams
{
    /// <summary>
    /// Тестирование запроса "Получить список больничных листов"
    /// </summary>
    public class GetSickListsByParamsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetSickListsByParamsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSickLists = FakeDbRepository.GetFakeSickLists();

            _fakeDbContext.Setup(set => set.SickLists).Returns(fakeSickLists.Object);
        }

        /// <summary>
        /// Тестирование получения списка больничных листов
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetSickListsByParamsTest()
        {
            // Arrange
            var accountingPeriod = _fakeDbContext.Object.SickLists.Max(rec => rec.AccountingPeriod);
            var count = _fakeDbContext.Object.SickLists.Count(rec => rec.AccountingPeriod == accountingPeriod);

            var query = new GetSickListsByParamsRequestHandler(_fakeDbContext.Object);
            var request = new GetSickListsByParamsRequest
            {
                StartPeriod = accountingPeriod,
                EndPeriod = accountingPeriod
            };

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
