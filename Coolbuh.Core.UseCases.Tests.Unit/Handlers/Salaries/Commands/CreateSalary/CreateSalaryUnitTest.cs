using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Salaries.Commands.CreateSalary;
using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Salaries.Commands.CreateSalary
{
    public class CreateSalaryUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateSalaryUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSalaries = FakeDbRepository.GetFakeSalaries();
            var employeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var departments = FakeDbRepository.GetFakeListDepartments();
            var pensionAllowances = FakeDbRepository.GetFakeListPensionAllowances();
            var gradeAllowances = FakeDbRepository.GetFakeListGradeAllowances();
            var otherAllowances = FakeDbRepository.GetFakeListOtherAllowances();

            _fakeDbContext.Setup(set => set.Salaries).Returns(fakeSalaries.Object);
            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(employeeCards.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(departments.Object);

            _fakeDbContext.Setup(set => set.ListPensionAllowances).Returns(pensionAllowances.Object);
            _fakeDbContext.Setup(set => set.ListGradeAllowances).Returns(gradeAllowances.Object);
            _fakeDbContext.Setup(set => set.ListOtherAllowances).Returns(otherAllowances.Object);
        }

        [Fact]
        public async Task CreateSalaryTest()
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

            var command = new CreateSalaryRequestHandler(_fakeDbContext.Object, fakeSalariesService.Object);
            var request = new CreateSalaryRequest
            {
                Salary = GetCreateSalaryDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.Salaries.AddAsync(It.IsAny<Salary>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(totalSum, result.TotalSum);
            Assert.Equal(pensionAllowanceSum, result.PensionAllowanceSum);
            Assert.Equal(otherAllowanceSum, result.OtherAllowanceSum);
            Assert.Equal(gradeAllowanceSum, result.GradeAllowanceSum);
        }

        private static CreateSalaryDto GetCreateSalaryDto()
        {
            return new CreateSalaryDto
            {
                EmployeeCardId = 1,
                DepartmentId = 1,
                AccountingPeriod = new DateTime(2022, 05, 01),
                Days = 10,
                Hours = 80,
                BaseSum = 100,
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
