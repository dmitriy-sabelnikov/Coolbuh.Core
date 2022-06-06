using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.DeleteCivilLawContract;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.CivilLawContracts.Commands.DeleteCivilLawContract
{
    /// <summary>
    /// Тестирование команды "Удалить договор ГПХ"
    /// </summary>
    public class DeleteCivilLawContractUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteCivilLawContractUnitTest()
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
        /// Тестирование удаления договора ГПХ
        /// </summary>
        [Fact]
        public async Task DeleteCivilLawContractTest()
        {
            // Arrange
            var command = new DeleteCivilLawContractRequestHandler(_fakeDbContext.Object);
            var request = new DeleteCivilLawContractRequest()
            {
                CivilLawContract = GetFakeDeleteCivilLawContractDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert

            _fakeDbContext.Verify(
                rec => rec.CivilLawContracts.Remove(It.IsAny<CivilLawContract>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Договор ГПХ"
        /// </summary>
        /// <returns>DTO удаления "Договор ГПХ"</returns>
        private static DeleteCivilLawContractDto GetFakeDeleteCivilLawContractDto()
        {
            return new DeleteCivilLawContractDto
            {
                Id = 1
            };
        }
    }
}
