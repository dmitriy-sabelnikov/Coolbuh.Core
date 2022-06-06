using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.DeleteListOtherAllowance;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListOtherAllowances.Commands.DeleteListOtherAllowance
{
    /// <summary>
    /// Тестирование команды "Удалить другую надбавку"
    /// </summary>
    public class DeleteListOtherAllowanceUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListOtherAllowanceUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeOtherAllowances = FakeDbRepository.GetFakeListOtherAllowances();

            _fakeDbContext.Setup(set => set.ListOtherAllowances).Returns(fakeOtherAllowances.Object);
        }

        /// <summary>
        /// Тестирование удаления другой надбавки
        /// </summary>
        [Fact]
        public async Task DeleteListOtherAllowanceTest()
        {
            // Arrange
            var command = new DeleteListOtherAllowanceRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListOtherAllowanceRequest
            {
                OtherAllowance = GetDeleteListOtherAllowanceDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListOtherAllowances.Remove(It.IsAny<ListOtherAllowance>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Другие надбавки"
        /// </summary>
        /// <returns>DTO удаления "Другие надбавки"</returns>
        private static DeleteListOtherAllowanceDto GetDeleteListOtherAllowanceDto()
        {
            return new DeleteListOtherAllowanceDto
            {
                Id = 1
            };
        }

    }
}
