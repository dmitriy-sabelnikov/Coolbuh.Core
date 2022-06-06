using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Payments.Commands.CreatePayment;
using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Payments.Commands.CreatePayment
{
    /// <summary>
    /// Тестирование команды "Создать выплату"
    /// </summary>
    public class CreatePaymentUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreatePaymentUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakePayments = FakeDbRepository.GetFakePayments();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.Payments).Returns(fakePayments.Object);
        }

        /// <summary>
        /// Тестирование создания выплаты
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreatePaymentTest()
        {
            // Arrange
            var fakePaymentsService = new Mock<IPaymentsService>();
            fakePaymentsService.Setup(service => service.ValidationEntity(It.IsAny<Payment>()));

            var command = new CreatePaymentRequestHandler(_fakeDbContext.Object, fakePaymentsService.Object);
            var request = new CreatePaymentRequest
            {
                Payment = GetCreatePaymentDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.Payments.AddAsync(It.IsAny<Payment>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Выплата"
        /// </summary>
        /// <returns>DTO создания "Выплата"</returns>
        private static CreatePaymentDto GetCreatePaymentDto()
        {
            return new CreatePaymentDto
            {
                EmployeeCardId = 1,
                AccountingPeriod = new DateTime(2022, 05, 01),
                Sum = 1
            };
        }
    }
}
