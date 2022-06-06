using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.SickLists.Commands.DeleteSickList;
using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.SickLists.Commands.DeleteSickList
{
    /// <summary>
    /// Тестирование команды "Удалить больничный лист"
    /// </summary>
    public class DeleteSickListUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteSickListUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();
            var fakeSickLists = FakeDbRepository.GetFakeSickLists();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
            _fakeDbContext.Setup(set => set.SickLists).Returns(fakeSickLists.Object);
        }

        /// <summary>
        /// Тестирование удаления больничного листа
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteSickListTest()
        {
            // Arrange
            var command = new DeleteSickListRequestHandler(_fakeDbContext.Object);
            var request = new DeleteSickListRequest
            {
                SickList = GetDeleteSickListDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.SickLists.Remove(It.IsAny<SickList>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Больничный лист"
        /// </summary>
        /// <returns>DTO удаления "Больничный лист"</returns>
        private static DeleteSickListDto GetDeleteSickListDto()
        {
            return new DeleteSickListDto
            {
                Id = 1
            };
        }
    }
}
