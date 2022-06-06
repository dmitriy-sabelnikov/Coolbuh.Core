using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Queries.GetEmployeeCardById;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.EmployeeCards.Queries.GetEmployeeCardById
{
    /// <summary>
    /// Тестирование запроса "Получить карточку работника" 
    /// </summary>
    public class GetEmployeeCardByIdUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetEmployeeCardByIdUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
        }

        /// <summary>
        /// Тестирование получения карточки работника 
        /// </summary>
        [Fact]
        public async Task GetEmployeeCardByIdTest()
        {
            // Arrange
            var employee = _fakeDbContext.Object.EmployeeCards.First();
            var query = new GetEmployeeCardByIdRequestHandler(_fakeDbContext.Object);
            var request = new GetEmployeeCardByIdRequest
            {
                Id = employee.Id
            };

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(employee.Id, result.Id);
        }
    }
}
