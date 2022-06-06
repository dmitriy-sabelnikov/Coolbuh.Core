using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Vocations.Queries.GetVocationsByParams;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Vocations.Queries.GetVocationsByParams
{
    /// <summary>
    /// Тестирование запроса "Получить список отпусков"
    /// </summary>
    public class GetVocationsByParamsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetVocationsByParamsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeVocations = FakeDbRepository.GetFakeVocations();

            _fakeDbContext.Setup(set => set.Vocations).Returns(fakeVocations.Object);
        }

        /// <summary>
        /// Тестирование получения списка отпусков
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetVocationsByParamsTest()
        {
            // Arrange
            var accountingPeriod = _fakeDbContext.Object.Vocations.Max(rec => rec.AccountingPeriod);
            var count = _fakeDbContext.Object.Vocations.Count(rec => rec.AccountingPeriod == accountingPeriod);

            var query = new GetVocationsByParamsRequestHandler(_fakeDbContext.Object);
            var request = new GetVocationsByParamsRequest
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
