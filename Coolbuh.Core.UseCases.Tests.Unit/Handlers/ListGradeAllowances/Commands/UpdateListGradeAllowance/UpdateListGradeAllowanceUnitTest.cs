using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.UpdateListGradeAllowance;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListGradeAllowances.Commands.UpdateListGradeAllowance
{
    /// <summary>
    /// Тестирование команды "Обновить надбавку за классность"
    /// </summary>
    public class UpdateListGradeAllowanceUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListGradeAllowanceUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeGradeAllowances = FakeDbRepository.GetFakeListGradeAllowances();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();

            _fakeDbContext.Setup(set => set.ListGradeAllowances).Returns(fakeGradeAllowances.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
        }

        /// <summary>
        /// Тестирование обновления надбавки за классность
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateListGradeAllowanceTest()
        {
            // Arrange
            var fakeGradeAllowancesService = new Mock<IListGradeAllowancesService>();
            fakeGradeAllowancesService.Setup(service => service.ValidationEntity(It.IsAny<ListGradeAllowance>()));

            var command = new UpdateListGradeAllowanceRequestHandler(_fakeDbContext.Object, fakeGradeAllowancesService.Object);
            var request = new UpdateListGradeAllowanceRequest
            {
                GradeAllowance = GetUpdateListGradeAllowanceDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListGradeAllowances.Update(It.IsAny<ListGradeAllowance>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.GradeAllowance.Id, result.Id);
            Assert.Equal(request.GradeAllowance.Percent, result.Percent);
        }

        /// <summary>
        /// Получить DTO обновления "Надбавки за классность"
        /// </summary>
        /// <returns>DTO обновления "Надбавки за классность"</returns>
        private static UpdateListGradeAllowanceDto GetUpdateListGradeAllowanceDto()
        {
            return new UpdateListGradeAllowanceDto
            {
                Id = 1,
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
