using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.CreateListOtherAllowance;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListOtherAllowances.Commands.CreateListOtherAllowance
{
    /// <summary>
    /// Тестирование команды "Создать другую надбавку"
    /// </summary>
    public class CreateListOtherAllowanceUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListOtherAllowanceUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeOtherAllowances = FakeDbRepository.GetFakeListOtherAllowances();

            _fakeDbContext.Setup(set => set.ListOtherAllowances).Returns(fakeOtherAllowances.Object);
        }

        /// <summary>
        /// Тестирование создания другой надбавки
        /// </summary>
        [Fact]
        public async Task CreateListOtherAllowanceTest()
        {
            // Arrange
            var fakeOtherAllowancesService = new Mock<IListOtherAllowancesService>();
            fakeOtherAllowancesService.Setup(service => service.ValidationEntity(It.IsAny<ListOtherAllowance>()));

            var command = new CreateListOtherAllowanceRequestHandler(_fakeDbContext.Object, fakeOtherAllowancesService.Object);
            var request = new CreateListOtherAllowanceRequest
            {
                OtherAllowance = GetCreateListOtherAllowanceDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListOtherAllowances.AddAsync(It.IsAny<ListOtherAllowance>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Другие надбавки"
        /// </summary>
        /// <returns>DTO создания "Другие надбавки"</returns>
        private static CreateListOtherAllowanceDto GetCreateListOtherAllowanceDto()
        {
            return new CreateListOtherAllowanceDto
            {
                Code = "3",
                Name = "тест",
                Percent = 20,
                UseAllowance = true
            };
        }
    }
}
