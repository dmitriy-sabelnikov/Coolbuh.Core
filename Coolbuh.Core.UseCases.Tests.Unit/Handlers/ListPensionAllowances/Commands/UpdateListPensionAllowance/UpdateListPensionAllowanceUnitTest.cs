using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.UpdateListPensionAllowance;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListPensionAllowances.Commands.UpdateListPensionAllowance
{
    /// <summary>
    /// Тестирование команды "Обновить надбавку за пенсию"
    /// </summary>
    public class UpdateListPensionAllowanceUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListPensionAllowanceUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakePensionAllowances = FakeDbRepository.GetFakeListPensionAllowances();

            _fakeDbContext.Setup(set => set.ListPensionAllowances).Returns(fakePensionAllowances.Object);
        }

        /// <summary>
        /// Тестирование обновления надбавки за пенсию
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateListPensionAllowanceTest()
        {
            // Arrange
            var fakePensionAllowancesService = new Mock<IListPensionAllowancesService>();
            fakePensionAllowancesService.Setup(service => service.ValidationEntity(It.IsAny<ListPensionAllowance>()));

            var command = new UpdateListPensionAllowanceRequestHandler(_fakeDbContext.Object, fakePensionAllowancesService.Object);
            var request = new UpdateListPensionAllowanceRequest
            {
                PensionAllowance = GetUpdateListPensionAllowanceDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListPensionAllowances.Update(It.IsAny<ListPensionAllowance>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.PensionAllowance.Id, result.Id);
            Assert.Equal(request.PensionAllowance.Percent, result.Percent);
        }

        /// <summary>
        /// Получить DTO обновления "Надбавки за пенсию"
        /// </summary>
        /// <returns>DTO обновления "Надбавки за пенсию"</returns>
        private static UpdateListPensionAllowanceDto GetUpdateListPensionAllowanceDto()
        {
            return new UpdateListPensionAllowanceDto
            {
                Id = 1,
                Code = "1",
                Name = "Test",
                Percent = 10,
                UseAllowance = true
            };
        }

    }
}
