using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.DeleteListSocialBenefit;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListSocialBenefits.Commands.DeleteListSocialBenefit
{
    /// <summary>
    /// Тестирование команды "Удалить социальную льготу"
    /// </summary>
    public class DeleteListSocialBenefitUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListSocialBenefitUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSocialBenefits = FakeDbRepository.GetFakeListSocialBenefits();

            _fakeDbContext.Setup(set => set.ListSocialBenefits).Returns(fakeSocialBenefits.Object);
        }

        /// <summary>
        /// Тестирование удаления социальной льготы
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteListSocialBenefitTest()
        {
            // Arrange
            var command = new DeleteListSocialBenefitRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListSocialBenefitRequest
            {
                SocialBenefit = GetDeleteListSocialBenefitDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListSocialBenefits.Remove(It.IsAny<ListSocialBenefit>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Социальные льготы"
        /// </summary>
        /// <returns>DTO удаления "Социальные льготы"</returns>
        private static DeleteListSocialBenefitDto GetDeleteListSocialBenefitDto()
        {
            return new DeleteListSocialBenefitDto
            {
                Id = 1
            };
        }
    }
}
