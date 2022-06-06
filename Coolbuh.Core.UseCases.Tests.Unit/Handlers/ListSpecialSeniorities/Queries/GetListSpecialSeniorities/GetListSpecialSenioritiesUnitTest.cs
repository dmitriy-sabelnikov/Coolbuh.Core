using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Queries.GetListSpecialSeniorities;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListSpecialSeniorities.Queries.GetListSpecialSeniorities
{
    /// <summary>
    /// Тестирование запроса "Получить список спецстажей"
    /// </summary>
    public class GetListSpecialSenioritiesUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListSpecialSenioritiesUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSpecialSeniorities = FakeDbRepository.GetFakeListSpecialSeniorities();

            _fakeDbContext.Setup(set => set.ListSpecialSeniorities).Returns(fakeSpecialSeniorities.Object);
        }

        /// <summary>
        /// Тестирование получения списка спецстажей
        /// </summary>
        /// <returns></returns>
        public async Task GetListSpecialSenioritiesTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListSpecialSeniorities.Count();

            var query = new GetListSpecialSenioritiesRequestHandler(_fakeDbContext.Object);
            var request = new GetListSpecialSenioritiesRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
