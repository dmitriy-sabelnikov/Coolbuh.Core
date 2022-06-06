using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.UpdateAdditionalPayment;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.AdditionalPayments.Commands.UpdateAdditionalPayment
{
    /// <summary>
    /// Тестирование команды "Обновить дополнительную выплату"
    /// </summary>
    public class UpdateAdditionalPaymentUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateAdditionalPaymentUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakeAdditionalPaymentTypes = FakeDbRepository.GetFakeListAdditionalPaymentTypes();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();
            var fakeAdditionalPayments = FakeDbRepository.GetFakeAdditionalPayments();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
            _fakeDbContext.Setup(set => set.ListAdditionalPaymentTypes).Returns(fakeAdditionalPaymentTypes.Object);
            _fakeDbContext.Setup(set => set.AdditionalPayments).Returns(fakeAdditionalPayments.Object);
        }

        /// <summary>
        /// Тестирование обновления дополнительной выплаты
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateAdditionalPaymentTest()
        {
            // Arrange
            var fakeAdditionalPaymentsService = new Mock<IAdditionalPaymentsService>();
            fakeAdditionalPaymentsService.Setup(service => service.ValidationEntity(It.IsAny<AdditionalPayment>()));

            var command = new UpdateAdditionalPaymentRequestHandler(_fakeDbContext.Object, fakeAdditionalPaymentsService.Object);

            var fakeAdditionalPayment = _fakeDbContext.Object.AdditionalPayments.First();

            var request = new UpdateAdditionalPaymentRequest
            {
                AdditionalPayment = GetFakeUpdateAdditionalPaymentDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
                rec => rec.AdditionalPayments.Update(It.IsAny<AdditionalPayment>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.AdditionalPayment.Id, result.Id);
            Assert.Equal(request.AdditionalPayment.Sum, result.Sum);
        }

        /// <summary>
        /// Получить DTO обновления "Дополнительная выплата"
        /// </summary>
        /// <param name="additionalAccrual">Дополнительная выплата</param>
        /// <returns>DTO обновления "Дополнительная выплата"</returns>
        private static UpdateAdditionalPaymentDto GetFakeUpdateAdditionalPaymentDto()
        {
            return new UpdateAdditionalPaymentDto
            {
                Id = 1,
                EmployeeCardId = 1,
                AdditionalPaymentTypeId = 1,
                AccountingPeriod = new DateTime(2022, 05, 01),
                Sum = 1
            };
        }
    }
}
