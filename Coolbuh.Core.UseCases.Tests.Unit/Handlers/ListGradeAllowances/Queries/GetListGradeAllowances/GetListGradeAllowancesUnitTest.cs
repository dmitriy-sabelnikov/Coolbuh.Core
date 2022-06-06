using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowances;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListGradeAllowances.Queries.GetListGradeAllowances
{
    /// <summary>
    /// Тестирование запроса "Получить список надбавок за классность"
    /// </summary>
    public class GetListGradeAllowancesUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListGradeAllowancesUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeGradeAllowances = FakeDbRepository.GetFakeListGradeAllowances();

            _fakeDbContext.Setup(set => set.ListGradeAllowances).Returns(fakeGradeAllowances.Object);
        }

        /// <summary>
        /// Тестирование получения списка надбавок за классность
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListGradeAllowancesTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListGradeAllowances.Count();
            var query = new GetListGradeAllowancesRequestHandler(_fakeDbContext.Object);
            var request = new GetListGradeAllowancesRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
