using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Queries.GetListPensionAllowances;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListPensionAllowances.Queries.GetListPensionAllowances
{
    /// <summary>
    /// Тестирование запроса "Получить список надбавок за пенсию"
    /// </summary>
    public class GetListPensionAllowancesUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListPensionAllowancesUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakePensionAllowances = FakeDbRepository.GetFakeListPensionAllowances();

            _fakeDbContext.Setup(set => set.ListPensionAllowances).Returns(fakePensionAllowances.Object);
        }

        /// <summary>
        /// Тестирование получения списка надбавок за пенсию
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListPensionAllowancesTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListPensionAllowances.Count();
            var query = new GetListPensionAllowancesRequestHandler(_fakeDbContext.Object);
            var request = new GetListPensionAllowancesRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
