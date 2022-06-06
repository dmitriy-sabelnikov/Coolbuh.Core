using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Payments.Queries.GetPaymentsByParams;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Payments.Queries.GetPaymentsByParams
{
    /// <summary>
    /// Тестирование запроса "Получить список отпусков"
    /// </summary>
    public class GetPaymentsByParamsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetPaymentsByParamsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakePayments = FakeDbRepository.GetFakePayments();

            _fakeDbContext.Setup(set => set.Payments).Returns(fakePayments.Object);
        }

        /// <summary>
        /// Тестирование получения списка отпусков
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetPaymentsByParamsTest()
        {
            // Arrange
            var accountingPeriod = _fakeDbContext.Object.Payments.Max(rec => rec.AccountingPeriod);
            var count = _fakeDbContext.Object.Payments.Count(rec => rec.AccountingPeriod == accountingPeriod);

            var query = new GetPaymentsByParamsRequestHandler(_fakeDbContext.Object);
            var request = new GetPaymentsByParamsRequest
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
