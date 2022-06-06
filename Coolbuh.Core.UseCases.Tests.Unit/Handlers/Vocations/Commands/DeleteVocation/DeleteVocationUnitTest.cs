using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Vocations.Commands.DeleteVocation;
using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Vocations.Commands.DeleteVocation
{
    /// <summary>
    /// Тестирование команды "Удалить отпуск"
    /// </summary>
    public class DeleteVocationUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteVocationUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();
            var fakeVocations = FakeDbRepository.GetFakeVocations();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
            _fakeDbContext.Setup(set => set.Vocations).Returns(fakeVocations.Object);
        }

        /// <summary>
        /// Тестирование удаления отпуска
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteVocationTest()
        {
            // Arrange
            var command = new DeleteVocationRequestHandler(_fakeDbContext.Object);
            var request = new DeleteVocationRequest
            {
                Vocation = GetDeleteVocationDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.Vocations.Remove(It.IsAny<Vocation>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Отпуск"
        /// </summary>
        /// <returns>DTO удаления "Отпуск"</returns>
        private static DeleteVocationDto GetDeleteVocationDto()
        {
            return new DeleteVocationDto
            {
                Id = 1
            };
        }
    }
}
