using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Queries.GetListAdditionalPaymentTypes;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdditionalPaymentTypes.Queries.GetListAdditionalPaymentTypes
{
    /// <summary>
    /// Тестирование запроса "Получить список типов дополнительных выплат"
    /// </summary>
    public class GetListAdditionalPaymentTypesUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListAdditionalPaymentTypesUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeListAdditionalPaymentTypes = FakeDbRepository.GetFakeListAdditionalPaymentTypes();

            _fakeDbContext.Setup(set => set.ListAdditionalPaymentTypes).Returns(fakeListAdditionalPaymentTypes.Object);
        }

        /// <summary>
        /// Тестирование получения списка типов дополнительных выплат
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListAdditionalPaymentTypesTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListAdditionalPaymentTypes.Count();
            var query = new GetListAdditionalPaymentTypesRequestHandler(_fakeDbContext.Object);
            var request = new GetListAdditionalPaymentTypesRequest
            { };

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
