using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.CreateListPensionAllowance;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListPensionAllowances.Commands.CreateListPensionAllowance
{
    /// <summary>
    /// Тестирование команды "Создать надбавку за пенсию"
    /// </summary>
    public class CreateListPensionAllowanceUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListPensionAllowanceUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakePensionAllowances = FakeDbRepository.GetFakeListPensionAllowances();

            _fakeDbContext.Setup(set => set.ListPensionAllowances).Returns(fakePensionAllowances.Object);
        }

        /// <summary>
        /// Тестирование создания надбавки за пенсию
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateListPensionAllowanceTest()
        {
            // Arrange
            var fakePensionAllowancesService = new Mock<IListPensionAllowancesService>();
            fakePensionAllowancesService.Setup(service => service.ValidationEntity(It.IsAny<ListPensionAllowance>()));

            var command = new CreateListPensionAllowanceRequestHandler(_fakeDbContext.Object, fakePensionAllowancesService.Object);
            var request = new CreateListPensionAllowanceRequest
            {
                PensionAllowance = GetCreateListPensionAllowanceDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListPensionAllowances.AddAsync(It.IsAny<ListPensionAllowance>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Надбавки за пенсию"
        /// </summary>
        /// <returns>DTO создания "Надбавки за пенсию"</returns>
        private static CreateListPensionAllowanceDto GetCreateListPensionAllowanceDto()
        {
            return new CreateListPensionAllowanceDto
            {
                Code = "3",
                Name = "Test",
                Percent = 10,
                UseAllowance = true
            };
        }
    }
}
