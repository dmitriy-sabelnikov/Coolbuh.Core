using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Queries.GetEmployeeCards;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.EmployeeCards.Queries.GetEmployeeCards
{
    /// <summary>
    /// Тестирование запроса "Получить карточки работников" 
    /// </summary>
    public class GetEmployeeCardsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetEmployeeCardsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
        }

        /// <summary>
        /// Тестирование получения карточек работнников
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetEmployeeCardsTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.EmployeeCards.Count();
            var query = new GetEmployeeCardsRequestHandler(_fakeDbContext.Object);
            var request = new GetEmployeeCardsRequest
            { };

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
