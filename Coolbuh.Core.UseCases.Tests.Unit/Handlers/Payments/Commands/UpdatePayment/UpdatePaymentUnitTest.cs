using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Payments.Commands.UpdatePayment;
using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Payments.Commands.UpdatePayment
{
    /// <summary>
    /// Тестирование команды "Обновить выплату"
    /// </summary>
    public class UpdatePaymentUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdatePaymentUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakePayments = FakeDbRepository.GetFakePayments();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.Payments).Returns(fakePayments.Object);
        }

        /// <summary>
        /// Тестирование обновления выплаты
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdatePaymentTest()
        {
            // Arrange
            var fakePaymentsService = new Mock<IPaymentsService>();
            fakePaymentsService.Setup(service => service.ValidationEntity(It.IsAny<Payment>()));

            var command = new UpdatePaymentRequestHandler(_fakeDbContext.Object, fakePaymentsService.Object);
            var request = new UpdatePaymentRequest
            {
                Payment = GetUpdatePaymentDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.Payments.Update(It.IsAny<Payment>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.Payment.Id, result.Id);
            Assert.Equal(request.Payment.Sum, result.Sum);
        }

        /// <summary>
        /// Получить DTO обновления "Выплата"
        /// </summary>
        /// <returns>DTO обновления "Выплата"</returns>
        private static UpdatePaymentDto GetUpdatePaymentDto()
        {
            return new UpdatePaymentDto
            {
                Id = 1,
                EmployeeCardId = 1,
                AccountingPeriod = new DateTime(2022, 05, 01),
                Sum = 1
            };
        }
    }
}
