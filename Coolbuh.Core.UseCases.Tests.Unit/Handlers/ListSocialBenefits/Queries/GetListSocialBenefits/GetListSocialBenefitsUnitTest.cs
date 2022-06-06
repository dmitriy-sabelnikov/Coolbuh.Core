using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Queries.GetListSocialBenefits;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListSocialBenefits.Queries.GetListSocialBenefits
{
    /// <summary>
    /// Тестирование запроса "Получить список социальных льгот"
    /// </summary>
    public class GetListSocialBenefitsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetListSocialBenefitsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSocialBenefits = FakeDbRepository.GetFakeListSocialBenefits();

            _fakeDbContext.Setup(set => set.ListSocialBenefits).Returns(fakeSocialBenefits.Object);
        }

        /// <summary>
        /// Тестирование получения списка социальных льгот
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListSocialBenefitsTest()
        {
            // Arrange
            var count = _fakeDbContext.Object.ListSocialBenefits.Count();

            var query = new GetListSocialBenefitsRequestHandler(_fakeDbContext.Object);
            var request = new GetListSocialBenefitsRequest();

            // Act
            var result = await query.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
