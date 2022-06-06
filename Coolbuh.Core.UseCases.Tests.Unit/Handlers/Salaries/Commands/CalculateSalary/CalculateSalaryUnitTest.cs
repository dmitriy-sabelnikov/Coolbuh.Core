using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Salaries.Commands.CalculateSalary;
using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Salaries.Commands.CalculateSalary
{
    public class CalculateSalaryUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CalculateSalaryUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSalaries = FakeDbRepository.GetFakeSalaries();
            var pensionAllowances = FakeDbRepository.GetFakeListPensionAllowances();
            var gradeAllowances = FakeDbRepository.GetFakeListGradeAllowances();
            var otherAllowances = FakeDbRepository.GetFakeListOtherAllowances();

            _fakeDbContext.Setup(set => set.Salaries).Returns(fakeSalaries.Object);
            _fakeDbContext.Setup(set => set.ListPensionAllowances).Returns(pensionAllowances.Object);
            _fakeDbContext.Setup(set => set.ListGradeAllowances).Returns(gradeAllowances.Object);
            _fakeDbContext.Setup(set => set.ListOtherAllowances).Returns(otherAllowances.Object);
        }

        [Fact]
        public async Task CalculateSalaryTest()
        {
            // Arrange
            var fakeSalariesService = new Mock<ISalariesService>();
            fakeSalariesService.Setup(service => service.ValidationEntity(It.IsAny<Salary>()));

            var totalSum = 1000;
            var pensionAllowanceSum = 10;
            var gradeAllowanceSum = 10;
            var otherAllowanceSum = 10;

            fakeSalariesService.Setup(
                service => service.CalculateSalaryResultSum(
                    It.IsAny<decimal>(),
                    It.IsAny<decimal>(),
                    It.IsAny<decimal>(),
                    It.IsAny<decimal>())
                ).Returns(totalSum);

            fakeSalariesService.Setup(
                service => service.CalculatePensionAllowanceSum(
                    It.IsAny<decimal>(),
                    It.IsAny<decimal>())
                ).Returns(pensionAllowanceSum);

            fakeSalariesService.Setup(
                service => service.CalculateGradeAllowanceSum(
                    It.IsAny<decimal>(),
                    It.IsAny<decimal>())
                ).Returns(gradeAllowanceSum);

            fakeSalariesService.Setup(
                service => service.CalculateOtherAllowanceSum(
                    It.IsAny<decimal>(),
                    It.IsAny<decimal>())
                ).Returns(otherAllowanceSum);

            var command = new CalculateSalaryRequestHandler(_fakeDbContext.Object, fakeSalariesService.Object);
            var request = new CalculateSalaryRequest()
            {
                Salary = GetCalculateSalaryDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(totalSum, result.TotalSum);
        }

        private static CalculateSalaryDto GetCalculateSalaryDto()
        {
            return new CalculateSalaryDto
            {
                BaseSum = 1000,
                PensionAllowanceId = 1,
                PensionAllowanceSum = 0,
                GradeAllowanceId = 1,
                GradeAllowanceSum = 0,
                OtherAllowanceId = 1,
                OtherAllowanceSum = 0
            };
        }
    }
}
