using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.UpdateCivilLawContract;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.CivilLawContracts.Commands.UpdateCivilLawContract
{
    /// <summary>
    /// Тестирование команды "Удалить договор ГПХ"
    /// </summary>
    public class UpdateCivilLawContractUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateCivilLawContractUnitTest()
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
        /// Тестирование обновления договора ГПХ
        /// </summary>
        [Fact]
        public async Task UpdateCivilLawContractTest()
        {
            // Arrange
            var fakeCivilLawContractsService = new Mock<ICivilLawContractsService>();
            fakeCivilLawContractsService.Setup(service => service.ValidationEntity(It.IsAny<CivilLawContract>()));

            var command = new UpdateCivilLawContractRequestHandler(_fakeDbContext.Object, fakeCivilLawContractsService.Object);
            var civilLawContractDto = GetFakeUpdateCivilLawContractDto();

            var request = new UpdateCivilLawContractRequest
            {
                CivilLawContract = civilLawContractDto
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
                rec => rec.CivilLawContracts.Update(It.IsAny<CivilLawContract>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(civilLawContractDto.Id, result.Id);
            Assert.Equal(civilLawContractDto.Sum, result.Sum);
        }

        /// <summary>
        /// Получить DTO обновления "Договор ГПХ"
        /// </summary>
        /// <returns>DTO обновления "Договор ГПХ"</returns>
        private static UpdateCivilLawContractDto GetFakeUpdateCivilLawContractDto()
        {
            return new UpdateCivilLawContractDto
            {
                Id = 1,
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
