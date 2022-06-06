using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.CreateCivilLawContract;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.CivilLawContracts.Commands.CreateCivilLawContract
{
    /// <summary>
    /// Тестирование команды "Создать договор ГПХ"
    /// </summary>
    public class CreateCivilLawContractUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateCivilLawContractUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();
            var fakeCivilLawContract = FakeDbRepository.GetFakeCivilLawContracts();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
            _fakeDbContext.Setup(set => set.CivilLawContracts).Returns(fakeCivilLawContract.Object);
        }

        /// <summary>
        /// Тестирование создания договора ГПХ
        /// </summary>
        [Fact]
        public async Task CreateCivilLawContractTest()
        {
            // Arrange
            var fakeCivilLawContractsService = new Mock<ICivilLawContractsService>();
            fakeCivilLawContractsService.Setup(service => service.ValidationEntity(It.IsAny<CivilLawContract>()));

            var command = new CreateCivilLawContractRequestHandler(_fakeDbContext.Object, fakeCivilLawContractsService.Object);

            var request = new CreateCivilLawContractRequest
            {
                CivilLawContract = GetCreateCivilLawContractDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
                rec => rec.CivilLawContracts.AddAsync(It.IsAny<CivilLawContract>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Договор ГПХ"
        /// </summary>
        /// <returns>DTO создания "Договор ГПХ"</returns>
        private static CreateCivilLawContractDto GetCreateCivilLawContractDto()
        {
            return new CreateCivilLawContractDto
            {
                DepartmentId = 1,
                EmployeeCardId = 1,
                AccountingPeriod = new DateTime(2022, 07, 01),
                AccrualPeriod = new DateTime(2022, 07, 01),
                Days = 1,
                Sum = 1
            };
        }
    }
}
