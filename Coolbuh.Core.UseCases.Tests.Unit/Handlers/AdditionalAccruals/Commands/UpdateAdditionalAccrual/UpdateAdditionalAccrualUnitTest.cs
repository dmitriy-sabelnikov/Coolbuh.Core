using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.UpdateAdditionalAccrual;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.AdditionalAccruals.Commands.UpdateAdditionalAccrual
{
    /// <summary>
    /// Тестирование команды "Обновить дополнительное начисление"
    /// </summary>
    public class UpdateAdditionalAccrualUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateAdditionalAccrualUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakeAdditionalAccrualTypes = FakeDbRepository.GetFakeListAdditionalAccrualTypes();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();
            var fakeAdditionalAccruals = FakeDbRepository.GetFakeAdditionalAccruals();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
            _fakeDbContext.Setup(set => set.ListAdditionalAccrualTypes).Returns(fakeAdditionalAccrualTypes.Object);
            _fakeDbContext.Setup(set => set.AdditionalAccruals).Returns(fakeAdditionalAccruals.Object);
        }

        /// <summary>
        /// Тестирование обновления дополнительного начисления
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateAdditionalAccrualTest()
        {
            // Arrange
            var fakeAdditionalAccrualsService = new Mock<IAdditionalAccrualsService>();
            fakeAdditionalAccrualsService.Setup(service => service.ValidationEntity(It.IsAny<AdditionalAccrual>()));

            var command = new UpdateAdditionalAccrualRequestHandler(_fakeDbContext.Object, fakeAdditionalAccrualsService.Object);

            var fakeAdditionalAccrual = _fakeDbContext.Object.AdditionalAccruals.First();

            var request = new UpdateAdditionalAccrualRequest
            {
                AdditionalAccrual = GetFakeUpdateAdditionalAccrualDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
                rec => rec.AdditionalAccruals.Update(It.IsAny<AdditionalAccrual>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.AdditionalAccrual.Id, result.Id);
            Assert.Equal(request.AdditionalAccrual.Sum, result.Sum);
        }

        /// <summary>
        /// Получить DTO обновления "Дополнительное начисление"
        /// </summary>
        /// <param name="additionalAccrual">Дополнительное начисление</param>
        /// <returns>DTO обновления "Дополнительное начисление"</returns>
        private static UpdateAdditionalAccrualDto GetFakeUpdateAdditionalAccrualDto()
        {
            return new UpdateAdditionalAccrualDto
            {
                Id = 1,
                EmployeeCardId = 1,
                DepartmentId = 1,
                AdditionalAccrualTypeId = 1,
                AccountingPeriod = new DateTime(2022, 05, 01),
                Sum = 20
            };
        }
    }
}
