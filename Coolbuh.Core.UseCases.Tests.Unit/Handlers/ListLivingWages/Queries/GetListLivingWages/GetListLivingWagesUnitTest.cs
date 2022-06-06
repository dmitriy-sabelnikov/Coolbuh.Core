using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Queries.GetListLivingWages;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListLivingWages.Queries.GetListLivingWages
{
    /// <summary>
    /// Тестирование запроса "Получить список прожиточных минимумов"
    /// </summary>
    public class GetListLivingWagesUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListLivingWagesUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeLivingWages = FakeDbRepository.GetFakeListLivingWages();

            _fakeDbContext.Setup(set => set.ListLivingWages).Returns(fakeLivingWages.Object);
        }

        /// <summary>
        /// Тестирование получения списка прожиточных минимумов
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListLivingWagesTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListLivingWages.Count();
            var query = new GetListLivingWagesRequestHandler(_fakeDbContext.Object);
            var request = new GetListLivingWagesRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
