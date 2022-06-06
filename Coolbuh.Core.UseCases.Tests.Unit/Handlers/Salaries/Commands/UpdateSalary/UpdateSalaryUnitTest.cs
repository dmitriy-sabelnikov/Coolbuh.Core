using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Salaries.Commands.UpdateSalary;
using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Salaries.Commands.UpdateSalary
{
    public class UpdateSalaryUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateSalaryUnitTest()
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
        public async Task UpdateSalaryTest()
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


            var command = new UpdateSalaryRequestHandler(_fakeDbContext.Object, fakeSalariesService.Object);
            var request = new UpdateSalaryRequest
            {
                Salary = GetUpdateSalaryDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.Salaries.Update(It.IsAny<Salary>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.Salary.Id, result.Id);
            Assert.Equal(totalSum, result.TotalSum);
            Assert.Equal(pensionAllowanceSum, result.PensionAllowanceSum);
            Assert.Equal(otherAllowanceSum, result.OtherAllowanceSum);
            Assert.Equal(gradeAllowanceSum, result.GradeAllowanceSum);
        }

        private static UpdateSalaryDto GetUpdateSalaryDto()
        {
            return new UpdateSalaryDto
            {
                Id = 1,
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
