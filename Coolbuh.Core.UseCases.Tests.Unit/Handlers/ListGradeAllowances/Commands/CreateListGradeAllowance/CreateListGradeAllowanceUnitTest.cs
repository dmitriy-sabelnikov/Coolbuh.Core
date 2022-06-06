using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.CreateListGradeAllowance;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListGradeAllowances.Commands.CreateListGradeAllowance
{
    /// <summary>
    /// Тестирование команды "Создать надбавку за классность"
    /// </summary>
    public class CreateListGradeAllowanceUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListGradeAllowanceUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeGradeAllowances = FakeDbRepository.GetFakeListGradeAllowances();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();

            _fakeDbContext.Setup(set => set.ListGradeAllowances).Returns(fakeGradeAllowances.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
        }

        /// <summary>
        /// Тестирование создания надбавки за классность
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateListGradeAllowanceTest()
        {
            // Arrange
            var fakeGradeAllowancesService = new Mock<IListGradeAllowancesService>();
            fakeGradeAllowancesService.Setup(service => service.ValidationEntity(It.IsAny<ListGradeAllowance>()));

            var command = new CreateListGradeAllowanceRequestHandler(_fakeDbContext.Object, fakeGradeAllowancesService.Object);
            var request = new CreateListGradeAllowanceRequest
            {
                GradeAllowance = GetCreateListGradeAllowanceDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListGradeAllowances.AddAsync(It.IsAny<ListGradeAllowance>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Надбавки за классность"
        /// </summary>
        /// <returns>DTO создания "Надбавки за классность"</returns>
        private static CreateListGradeAllowanceDto GetCreateListGradeAllowanceDto()
        {
            return new CreateListGradeAllowanceDto
            {
                Code = "3",
                Name = "тест",
                Percent = 20,
                Grade = 1,
                DepartmentId = 1,
                UseAllowance = true
            };
        }
    }
}
