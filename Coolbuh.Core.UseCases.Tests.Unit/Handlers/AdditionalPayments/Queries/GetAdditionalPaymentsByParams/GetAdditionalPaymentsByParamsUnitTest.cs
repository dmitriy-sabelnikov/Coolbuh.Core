using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Queries.GetAdditionalPaymentsByParams;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.AdditionalPayments.Queries.GetAdditionalPaymentsByParams
{
    /// <summary>
    /// Тестирование запроса "Получить список дополнительных выплат"
    /// </summary>
    public class GetAdditionalPaymentsByParamsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetAdditionalPaymentsByParamsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeAdditionalPayments = FakeDbRepository.GetFakeAdditionalPayments();

            _fakeDbContext.Setup(set => set.AdditionalPayments).Returns(fakeAdditionalPayments.Object);
        }

        /// <summary>
        /// Тестирование получения списка дополнительных выплат
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAdditionalPaymentsByParams()
        {
            // Arrange
            var accountingPeriod = _fakeDbContext.Object.AdditionalPayments.Max(rec => rec.AccountingPeriod);
            var count = _fakeDbContext.Object.AdditionalPayments.Count(rec => rec.AccountingPeriod == accountingPeriod);
            var request = new GetAdditionalPaymentsByParamsRequest
            {
                StartPeriod = accountingPeriod,
                EndPeriod = accountingPeriod
            };

            var query = new GetAdditionalPaymentsByParamsRequestHandler(_fakeDbContext.Object);

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
