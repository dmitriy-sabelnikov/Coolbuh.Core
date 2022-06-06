using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.UpdateListOtherAllowance;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListOtherAllowances.Commands.UpdateListOtherAllowance
{
    /// <summary>
    /// Тестирование команды "Обновить другую надбавку"
    /// </summary>
    public class UpdateListOtherAllowanceUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListOtherAllowanceUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeOtherAllowances = FakeDbRepository.GetFakeListOtherAllowances();

            _fakeDbContext.Setup(set => set.ListOtherAllowances).Returns(fakeOtherAllowances.Object);
        }

        /// <summary>
        /// Тестирование обновления другой надбавки
        /// </summary>
        [Fact]
        public async Task UpdateListOtherAllowanceTest()
        {
            // Arrange
            var fakeOtherAllowancesService = new Mock<IListOtherAllowancesService>();
            fakeOtherAllowancesService.Setup(service => service.ValidationEntity(It.IsAny<ListOtherAllowance>()));

            var command = new UpdateListOtherAllowanceRequestHandler(_fakeDbContext.Object, fakeOtherAllowancesService.Object);
            var request = new UpdateListOtherAllowanceRequest
            {
                OtherAllowance = GetUpdateListOtherAllowanceDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListOtherAllowances.Update(It.IsAny<ListOtherAllowance>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.OtherAllowance.Id, result.Id);
            Assert.Equal(request.OtherAllowance.Percent, result.Percent);
        }

        /// <summary>
        /// Получить DTO обновления "Другие надбавки"
        /// </summary>
        /// <returns>DTO обновления "Другие надбавки"</returns>
        private static UpdateListOtherAllowanceDto GetUpdateListOtherAllowanceDto()
        {
            return new UpdateListOtherAllowanceDto
            {
                Id = 1,
                Code = "1",
                Name = "тест",
                Percent = 20,
                UseAllowance = true
            };
        }
    }
}
