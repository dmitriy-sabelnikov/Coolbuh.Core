using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.CreateListLivingWage;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListLivingWages.Commands.CreateListLivingWage
{
    /// <summary>
    /// Тестирование команды "Создать прожиточный минимум"
    /// </summary>
    public class CreateListLivingWageUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListLivingWageUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeLivingWages = FakeDbRepository.GetFakeListLivingWages();

            _fakeDbContext.Setup(set => set.ListLivingWages).Returns(fakeLivingWages.Object);
        }

        /// <summary>
        /// Тестирование создания прожиточного минимума
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateListLivingWageTest()
        {
            // Arrange
            var fakeLivingWagesService = new Mock<IListLivingWagesService>();
            fakeLivingWagesService.Setup(service => service.ValidationEntity(It.IsAny<ListLivingWage>()));

            var command = new CreateListLivingWageRequestHandler(_fakeDbContext.Object, fakeLivingWagesService.Object);
            var request = new CreateListLivingWageRequest
            {
                LivingWage = GetCreateListMinimumSalaryDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListLivingWages.AddAsync(It.IsAny<ListLivingWage>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Прожиточные минимумы"
        /// </summary>
        /// <returns>DTO создания "Прожиточные минимумы"</returns>
        private static CreateListLivingWageDto GetCreateListMinimumSalaryDto()
        {
            return new CreateListLivingWageDto
            {
                PeriodBegin = new DateTime(2022, 05, 01),
                PeriodEnd = new DateTime(2022, 06, 01),
                Sum = 100
            };
        }
    }
}
