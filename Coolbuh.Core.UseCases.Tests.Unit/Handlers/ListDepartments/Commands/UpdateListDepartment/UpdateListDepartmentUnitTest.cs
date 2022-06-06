using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.UpdateListDepartment;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListDepartments.Commands.UpdateListDepartment
{
    /// <summary>
    /// Тестирование команды "Обновить подразделение"
    /// </summary>
    public class UpdateListDepartmentUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListDepartmentUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();

            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
        }

        /// <summary>
        /// Тестирование обновления подразделения
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateListDepartmentTest()
        {
            // Arrange
            var fakeDepartmentsService = new Mock<IListDepartmentsService>();
            fakeDepartmentsService.Setup(service => service.ValidationEntity(It.IsAny<ListDepartment>()));

            var command = new UpdateListDepartmentRequestHandler(_fakeDbContext.Object, fakeDepartmentsService.Object);
            var request = new UpdateListDepartmentRequest
            {
                Department = GetUpdateListDepartmentDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListDepartments.Update(It.IsAny<ListDepartment>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.Department.Id, result.Id);
            Assert.Equal(request.Department.Name, result.Name);
        }

        /// <summary>
        /// Получить DTO обновления "Подразделения"
        /// </summary>
        /// <returns>DTO обновления "Подразделения"</returns>
        private static UpdateListDepartmentDto GetUpdateListDepartmentDto()
        {
            return new UpdateListDepartmentDto
            {
                Id = 1,
                Code = "3",
                Name = "тест",
            };
        }
    }
}
