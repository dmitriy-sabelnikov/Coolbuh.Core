using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Queries.GetListOtherAllowances;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListOtherAllowances.Queries.GetListOtherAllowances
{
    /// <summary>
    /// Тестирование запроса "Получить список надбавок"
    /// </summary>
    public class GetListOtherAllowancesUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListOtherAllowancesUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeOtherAllowances = FakeDbRepository.GetFakeListOtherAllowances();

            _fakeDbContext.Setup(set => set.ListOtherAllowances).Returns(fakeOtherAllowances.Object);
        }

        /// <summary>
        /// Тестирование получения списка надбавок
        /// </summary>
        [Fact]
        public async Task GetListOtherAllowancesTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListOtherAllowances.Count();
            var query = new GetListOtherAllowancesRequestHandler(_fakeDbContext.Object);
            var request = new GetListOtherAllowancesRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
