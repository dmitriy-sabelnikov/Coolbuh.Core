using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Queries.GetListMinimumSalaries;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListMinimumSalaries.Queries.GetListMinimumSalaries
{
    /// <summary>
    /// Тестирование запроса "Получить список минимальных зарплат"
    /// </summary>
    public class GetListMinimumSalariesUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListMinimumSalariesUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeMinimumSalaries = FakeDbRepository.GetFakeListMinimumSalaries();

            _fakeDbContext.Setup(set => set.ListMinimumSalaries).Returns(fakeMinimumSalaries.Object);
        }

        /// <summary>
        /// Тестирование получения списка минимальных зарплат
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListMinimumSalariesTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListMinimumSalaries.Count();
            var query = new GetListMinimumSalariesRequestHandler(_fakeDbContext.Object);
            var request = new GetListMinimumSalariesRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
