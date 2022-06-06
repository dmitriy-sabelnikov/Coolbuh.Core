using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListPositions.Queries.GetListPositions;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListPositions.Queries.GetListPositions
{
    /// <summary>
    /// Тестирование запроса "Получить список должностей"
    /// </summary>
    public class GetListPositionsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListPositionsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakePositions = FakeDbRepository.GetFakeListPositions();

            _fakeDbContext.Setup(set => set.ListPositions).Returns(fakePositions.Object);
        }

        /// <summary>
        /// Тестирование получения списка должностей
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListPositionsTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListPositions.Count();

            var query = new GetListPositionsRequestHandler(_fakeDbContext.Object);
            var request = new GetListPositionsRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
