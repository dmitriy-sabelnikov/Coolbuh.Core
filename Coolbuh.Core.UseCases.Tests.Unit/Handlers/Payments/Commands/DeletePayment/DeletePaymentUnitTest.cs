using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Payments.Commands.DeletePayment;
using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Payments.Commands.DeletePayment
{
    /// <summary>
    /// Тестирование команды "Удалить выплату"
    /// </summary>
    public class DeletePaymentUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeletePaymentUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakePayments = FakeDbRepository.GetFakePayments();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.Payments).Returns(fakePayments.Object);
        }

        /// <summary>
        /// Тестирование удаления выплаты
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeletePaymentTest()
        {
            // Arrange
            var command = new DeletePaymentRequestHandler(_fakeDbContext.Object);
            var request = new DeletePaymentRequest
            {
                Payment = GetDeletePaymentDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.Payments.Remove(It.IsAny<Payment>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Выплата"
        /// </summary>
        /// <returns>DTO удаления "Выплата"</returns>
        private static DeletePaymentDto GetDeletePaymentDto()
        {
            return new DeletePaymentDto
            {
                Id = 1
            };
        }

    }
}
