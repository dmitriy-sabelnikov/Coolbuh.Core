using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.DeleteListGradeAllowance;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListGradeAllowances.Commands.DeleteListGradeAllowance
{
    /// <summary>
    /// Тестирование команды "Удалить надбавку за классность"
    /// </summary>
    public class DeleteListGradeAllowanceUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListGradeAllowanceUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeGradeAllowances = FakeDbRepository.GetFakeListGradeAllowances();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();

            _fakeDbContext.Setup(set => set.ListGradeAllowances).Returns(fakeGradeAllowances.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
        }

        /// <summary>
        /// Тестирование удаления надбавки за классность
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteListGradeAllowanceTest()
        {
            // Arrange
            var command = new DeleteListGradeAllowanceRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListGradeAllowanceRequest
            {
                GradeAllowance = GetDeleteListGradeAllowanceDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListGradeAllowances.Remove(It.IsAny<ListGradeAllowance>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Надбавки за классность"
        /// </summary>
        /// <returns>DTO удаления "Надбавки за классность"</returns>
        private static DeleteListGradeAllowanceDto GetDeleteListGradeAllowanceDto()
        {
            return new DeleteListGradeAllowanceDto
            {
                Id = 1
            };
        }
    }
}
