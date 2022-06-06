using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.DeleteEmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.EmployeeCards.Commands.DeleteEmployeeCard
{
    /// <summary>
    /// Тестирование команды "Удалить карточку работника"
    /// </summary>
    public class DeleteEmployeeCardUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteEmployeeCardUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
        }

        /// <summary>
        /// Тестирование удаления карточки работника
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteEmployeeCardTest()
        {
            // Arrange
            var command = new DeleteEmployeeCardRequestHandler(_fakeDbContext.Object);
            var request = new DeleteEmployeeCardRequest
            {
                EmployeeCard = GetDeleteEmployeeCardDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.EmployeeCards.Remove(It.IsAny<EmployeeCard>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Карточка работника"
        /// </summary>
        /// <returns>DTO удаления "Карточка работника"</returns>
        private static DeleteEmployeeCardDto GetDeleteEmployeeCardDto()
        {
            return new DeleteEmployeeCardDto
            {
                Id = 1
            };
        }
    }
}
