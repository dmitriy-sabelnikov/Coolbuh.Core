using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Queries.GetListAdditionalAccrualTypes;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdditionalAccrualTypes.Queries.GetListAdditionalAccrualTypes
{
    /// <summary>
    /// Тестирование запроса "Получить типы дополнительных начислений"
    /// </summary>
    public class GetListAdditionalAccrualTypesUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListAdditionalAccrualTypesUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeListAdditionalAccrualTypes = FakeDbRepository.GetFakeListAdditionalAccrualTypes();

            _fakeDbContext.Setup(set => set.ListAdditionalAccrualTypes).Returns(fakeListAdditionalAccrualTypes.Object);
        }

        /// <summary>
        /// Тестирование получения типа дополнительных начислений
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListAdditionalAccrualTypesTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListAdditionalAccrualTypes.Count();
            var query = new GetListAdditionalAccrualTypesRequestHandler(_fakeDbContext.Object);
            var request = new GetListAdditionalAccrualTypesRequest
            { };

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
