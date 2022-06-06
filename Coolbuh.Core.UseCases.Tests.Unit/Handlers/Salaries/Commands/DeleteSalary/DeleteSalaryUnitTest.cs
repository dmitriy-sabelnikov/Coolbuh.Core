using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Salaries.Commands.DeleteSalary;
using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Salaries.Commands.DeleteSalary
{
    public class DeleteSalaryUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteSalaryUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSalaries = FakeDbRepository.GetFakeSalaries();

            _fakeDbContext.Setup(set => set.Salaries).Returns(fakeSalaries.Object);
        }

        [Fact]
        public async Task DeleteSalaryTest()
        {
            // Arrange
            var command = new DeleteSalaryRequestHandler(_fakeDbContext.Object);
            var request = new DeleteSalaryRequest
            {
                Salary = GetDeleteSalaryDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.Salaries.Remove(It.IsAny<Salary>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        private static DeleteSalaryDto GetDeleteSalaryDto()
        {
            return new DeleteSalaryDto
            {
                Id = 1
            };
        }
    }
}
