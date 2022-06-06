using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Queries.GetListAdministrations;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdministrations.Queries.GetListAdministrations
{
    /// <summary>
    /// Тестирование запроса "Получить список администрации"
    /// </summary>
    public class GetListAdministrationsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListAdministrationsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeAdministrations = FakeDbRepository.GetFakeListAdministrations();

            _fakeDbContext.Setup(set => set.ListAdministrations).Returns(fakeAdministrations.Object);
        }

        /// <summary>
        /// Тестирование получения списка администраций
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListAdministrationsTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListAdministrations.Count();
            var query = new GetListAdministrationsRequestHandler(_fakeDbContext.Object);
            var request = new GetListAdministrationsRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
