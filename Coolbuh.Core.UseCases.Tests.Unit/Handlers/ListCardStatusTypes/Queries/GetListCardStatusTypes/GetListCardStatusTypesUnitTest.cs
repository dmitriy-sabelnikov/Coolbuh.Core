using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Queries.GetListCardStatusTypes;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListCardStatusTypes.Queries.GetListCardStatusTypes
{
    /// <summary>
    /// Тестирование запроса "Получить список типов статусов карточки"
    /// </summary>
    public class GetListCardStatusTypesUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListCardStatusTypesUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeCardStatusTypes = FakeDbRepository.GetFakeListCardStatusTypes();

            _fakeDbContext.Setup(set => set.ListCardStatusTypes).Returns(fakeCardStatusTypes.Object);
        }

        /// <summary>
        /// Тестирование получения списка типов статусов карточки
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListCardStatusTypesTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListCardStatusTypes.Count();
            var query = new GetListCardStatusTypesRequestHandler(_fakeDbContext.Object);
            var request = new GetListCardStatusTypesRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
