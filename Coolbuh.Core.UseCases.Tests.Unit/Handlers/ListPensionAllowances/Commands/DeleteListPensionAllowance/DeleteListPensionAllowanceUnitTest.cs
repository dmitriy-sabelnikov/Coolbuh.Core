using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.DeleteListPensionAllowance;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListPensionAllowances.Commands.DeleteListPensionAllowance
{
    /// <summary>
    /// Тестирование команды "Удалить надбавку за пенсию"
    /// </summary>
    public class DeleteListPensionAllowanceUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListPensionAllowanceUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakePensionAllowances = FakeDbRepository.GetFakeListPensionAllowances();

            _fakeDbContext.Setup(set => set.ListPensionAllowances).Returns(fakePensionAllowances.Object);
        }

        /// <summary>
        /// Тестирование удаления надбавки за пенсию
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteListPensionAllowanceTest()
        {
            // Arrange
            var command = new DeleteListPensionAllowanceRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListPensionAllowanceRequest
            {
                PensionAllowance = GetDeleteListPensionAllowanceDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListPensionAllowances.Remove(It.IsAny<ListPensionAllowance>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Надбавки за пенсию"
        /// </summary>
        /// <returns>DTO удаления "Надбавки за пенсию"</returns>
        private static DeleteListPensionAllowanceDto GetDeleteListPensionAllowanceDto()
        {
            return new DeleteListPensionAllowanceDto
            {
                Id = 1
            };
        }
    }
}
