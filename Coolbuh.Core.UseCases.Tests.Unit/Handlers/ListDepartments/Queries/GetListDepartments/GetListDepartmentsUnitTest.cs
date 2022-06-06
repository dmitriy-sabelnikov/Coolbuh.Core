using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Queries.GetListDepartments;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListDepartments.Queries.GetListDepartments
{
    /// <summary>
    /// Тестирование запроса "Получить список подразделений"
    /// </summary>
    public class GetListDepartmentsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListDepartmentsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();

            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
        }

        /// <summary>
        /// Тестирование получения списка подразделений
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListDepartmentsTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListDepartments.Count();
            var query = new GetListDepartmentsRequestHandler(_fakeDbContext.Object);
            var request = new GetListDepartmentsRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
