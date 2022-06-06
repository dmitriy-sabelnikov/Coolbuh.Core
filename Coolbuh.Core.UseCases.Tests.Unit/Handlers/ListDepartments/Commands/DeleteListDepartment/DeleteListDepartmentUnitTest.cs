using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.DeleteListDepartment;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListDepartments.Commands.DeleteListDepartment
{
    /// <summary>
    /// Тестирование команды "Удалить подразделение"
    /// </summary>
    public class DeleteListDepartmentUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListDepartmentUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();

            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
        }

        /// <summary>
        /// Тестирование удаление подразделения
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteListDepartmentTest()
        {
            // Arrange
            var command = new DeleteListDepartmentRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListDepartmentRequest
            {
                Department = GetDeleteListDepartmentDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListDepartments.Remove(It.IsAny<ListDepartment>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Подразделения"
        /// </summary>
        /// <returns>DTO удаления "Подразделения"</returns>
        private static DeleteListDepartmentDto GetDeleteListDepartmentDto()
        {
            return new DeleteListDepartmentDto
            {
                Id = 1
            };
        }
    }
}
