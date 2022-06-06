using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.DeleteListSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListSpecialSeniorities.Commands.DeleteListSpecialSeniority
{
    /// <summary>
    /// Тестирование команды "Удалить спецстаж"
    /// </summary>
    public class DeleteListSpecialSeniorityUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListSpecialSeniorityUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSpecialSeniorities = FakeDbRepository.GetFakeListSpecialSeniorities();

            _fakeDbContext.Setup(set => set.ListSpecialSeniorities).Returns(fakeSpecialSeniorities.Object);
        }

        /// <summary>
        /// Тестирование удаления спецстажа
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteListSpecialSeniorityTest()
        {
            // Arrange
            var command = new DeleteListSpecialSeniorityRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListSpecialSeniorityRequest
            {
                SpecialSeniority = GetDeleteListSpecialSeniorityDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListSpecialSeniorities.Remove(It.IsAny<ListSpecialSeniority>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Спецстажи"
        /// </summary>
        /// <returns>DTO удаления "Спецстажи"</returns>
        private static DeleteListSpecialSeniorityDto GetDeleteListSpecialSeniorityDto()
        {
            return new DeleteListSpecialSeniorityDto
            {
                Id = 1
            };
        }
    }
}
