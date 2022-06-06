using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Salaries.Queries.GetSalaries;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Salaries.Queries.GetSalaries
{
    public class GetSalariesUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetSalariesUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSalaries = FakeDbRepository.GetFakeSalaries();

            _fakeDbContext.Setup(set => set.Salaries).Returns(fakeSalaries.Object);
        }

        [Fact]
        public async Task GetSalariesTest()
        {
            // Arrange
            var accountingPeriod = _fakeDbContext.Object.Salaries.Max(rec => rec.AccountingPeriod);
            var count = _fakeDbContext.Object.Salaries
                .Where(rec => rec.AccountingPeriod >= accountingPeriod &&
                              rec.AccountingPeriod <= accountingPeriod)
                .Count();

            var query = new GetSalariesRequestHandler(_fakeDbContext.Object);

            var request = new GetSalariesRequest()
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
