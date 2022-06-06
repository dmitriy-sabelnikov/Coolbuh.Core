using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Queries.GetCivilLawContractsByParams;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.CivilLawContracts.Queries.GetCivilLawContractsByParams
{
    /// <summary>
    /// Тестирование запроса "Получить список договоров ГПХ"
    /// </summary>
    public class GetCivilLawContractsByParamsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetCivilLawContractsByParamsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeCivilLawContract = FakeDbRepository.GetFakeCivilLawContracts();

            _fakeDbContext.Setup(set => set.CivilLawContracts).Returns(fakeCivilLawContract.Object);
        }

        /// <summary>
        /// Тестирование получения списка договоров ГПХ
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetCivilLawContractsByParamsTest()
        {
            // Arrange
            var accountingPeriod = _fakeDbContext.Object.CivilLawContracts.Max(rec => rec.AccountingPeriod);
            var count = _fakeDbContext.Object.CivilLawContracts.Count(rec => rec.AccountingPeriod == accountingPeriod);
            var request = new GetCivilLawContractsByParamsRequest
            {
                StartPeriod = accountingPeriod,
                EndPeriod = accountingPeriod
            };

            var query = new GetCivilLawContractsByParamsRequestHandler(_fakeDbContext.Object);

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
