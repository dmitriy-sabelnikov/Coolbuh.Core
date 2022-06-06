using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.DeleteListAdministration;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdministrations.Commands.DeleteListAdministration
{
    /// <summary>
    /// Тестирование команды "Удалить администрацию"
    /// </summary>
    public class DeleteListAdministrationUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListAdministrationUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeAdministrations = FakeDbRepository.GetFakeListAdministrations();

            _fakeDbContext.Setup(set => set.ListAdministrations).Returns(fakeAdministrations.Object);
        }

        /// <summary>
        /// Тестирование удаления администрации
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteListAdministrationTest()
        {
            // Arrange
            var command = new DeleteListAdministrationRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListAdministrationRequest
            {
                Administration = GetDeleteListAdministrationDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListAdministrations.Remove(It.IsAny<ListAdministration>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Администрации"
        /// </summary>
        /// <returns>DTO удаления "Администрации"</returns>
        private static DeleteListAdministrationDto GetDeleteListAdministrationDto()
        {
            return new DeleteListAdministrationDto
            {
                Id = 1
            };
        }

    }
}
