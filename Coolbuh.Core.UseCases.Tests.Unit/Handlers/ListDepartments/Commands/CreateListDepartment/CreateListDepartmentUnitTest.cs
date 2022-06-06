using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.CreateListDepartment;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListDepartments.Commands.CreateListDepartment
{
    /// <summary>
    /// Тестирование команды "Создать подразделение"
    /// </summary>
    public class CreateListDepartmentUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListDepartmentUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();

            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
        }

        /// <summary>
        /// Тестирование создание подразделения
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateListDepartmentTest()
        {
            // Arrange
            var fakeDepartmentsService = new Mock<IListDepartmentsService>();
            fakeDepartmentsService.Setup(service => service.ValidationEntity(It.IsAny<ListDepartment>()));

            var command = new CreateListDepartmentRequestHandler(_fakeDbContext.Object, fakeDepartmentsService.Object);
            var request = new CreateListDepartmentRequest
            {
                Department = GetCreateListDepartmentDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListDepartments.AddAsync(It.IsAny<ListDepartment>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Подразделения"
        /// </summary>
        /// <returns>DTO создания "Подразделения"</returns>
        private static CreateListDepartmentDto GetCreateListDepartmentDto()
        {
            return new CreateListDepartmentDto
            {
                Code = "3",
                Name = "тест",
            };
        }
    }
}
