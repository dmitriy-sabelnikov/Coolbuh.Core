using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.UpdateListSocialBenefit;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListSocialBenefits.Commands.UpdateListSocialBenefit
{
    /// <summary>
    /// Тестирование команды "Обновить социальную льготу"
    /// </summary>
    public class UpdateListSocialBenefitUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListSocialBenefitUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSocialBenefits = FakeDbRepository.GetFakeListSocialBenefits();

            _fakeDbContext.Setup(set => set.ListSocialBenefits).Returns(fakeSocialBenefits.Object);
        }

        /// <summary>
        /// Тестирование обновления социальной льготы
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateListSocialBenefitTest()
        {
            // Arrange
            var fakeSocialBenefitsService = new Mock<IListSocialBenefitsService>();
            fakeSocialBenefitsService.Setup(service => service.ValidationEntity(It.IsAny<ListSocialBenefit>()));

            var command = new UpdateListSocialBenefitRequestHandler(_fakeDbContext.Object, fakeSocialBenefitsService.Object);
            var request = new UpdateListSocialBenefitRequest
            {
                SocialBenefit = GetUpdateListSocialBenefitDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListSocialBenefits.Update(It.IsAny<ListSocialBenefit>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.SocialBenefit.Id, result.Id);
            Assert.Equal(request.SocialBenefit.Sum, result.Sum);
        }

        /// <summary>
        /// Получить DTO обновления "Социальные льготы"
        /// </summary>
        /// <returns>DTO обновления "Социальные льготы"</returns>
        private static UpdateListSocialBenefitDto GetUpdateListSocialBenefitDto()
        {
            return new UpdateListSocialBenefitDto
            {
                Id = 1,
                PeriodBegin = new DateTime(2022, 05, 01),
                PeriodEnd = new DateTime(2022, 06, 01),
                Sum = 10,
                LimitSum = 20
            };
        }

    }
}
