using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.CreateListSocialBenefit;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListSocialBenefits.Commands.CreateListSocialBenefit
{
    /// <summary>
    /// Тестирование команды "Создать социальную льготу"
    /// </summary>
    public class CreateListSocialBenefitUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListSocialBenefitUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSocialBenefits = FakeDbRepository.GetFakeListSocialBenefits();

            _fakeDbContext.Setup(set => set.ListSocialBenefits).Returns(fakeSocialBenefits.Object);
        }

        /// <summary>
        /// Тестирование создания социальной льготы
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateListSocialBenefitTest()
        {
            // Arrange
            var fakeSocialBenefitsService = new Mock<IListSocialBenefitsService>();
            fakeSocialBenefitsService.Setup(service => service.ValidationEntity(It.IsAny<ListSocialBenefit>()));

            var command = new CreateListSocialBenefitRequestHandler(_fakeDbContext.Object, fakeSocialBenefitsService.Object);
            var request = new CreateListSocialBenefitRequest
            {
                SocialBenefit = GetCreateListSocialBenefitDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListSocialBenefits.AddAsync(It.IsAny<ListSocialBenefit>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Социальные льготы"
        /// </summary>
        /// <returns>DTO создания "Социальные льготы"</returns>
        private static CreateListSocialBenefitDto GetCreateListSocialBenefitDto()
        {
            return new CreateListSocialBenefitDto
            {
                PeriodBegin = new DateTime(2022, 05, 01),
                PeriodEnd = new DateTime(2022, 06, 01),
                Sum = 10,
                LimitSum = 20
            };
        }
    }
}
