using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Queries.GetAdditionalAccrualsByParams;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.AdditionalAccruals.Queries.GetAdditionalAccrualsByParams
{
    /// <summary>
    /// Тестирование запроса "Получить список дополнительных начислений"
    /// </summary>
    public class GetAdditionalAccrualsByParamsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetAdditionalAccrualsByParamsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeAdditionalAccruals = FakeDbRepository.GetFakeAdditionalAccruals();

            _fakeDbContext.Setup(set => set.AdditionalAccruals).Returns(fakeAdditionalAccruals.Object);
        }

        /// <summary>
        /// Тестирование получения списка дополнительных начислений
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAdditionalAccrualsByParams()
        {
            // Arrange
            var accountingPeriod = _fakeDbContext.Object.AdditionalAccruals.Max(rec => rec.AccountingPeriod);
            var count = _fakeDbContext.Object.AdditionalAccruals.Count(rec => rec.AccountingPeriod == accountingPeriod);
            var request = new GetAdditionalAccrualsByParamsRequest
            {
                StartPeriod = accountingPeriod,
                EndPeriod = accountingPeriod
            };

            var query = new GetAdditionalAccrualsByParamsRequestHandler(_fakeDbContext.Object);

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
