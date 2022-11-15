using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.DeleteAdditionalPayment;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.AdditionalPayments.Commands.DeleteAdditionalPayment
{
    /// <summary>
    /// Тестирование команды "Удалить дополнительную выплату"
    /// </summary>
    public class DeleteAdditionalPaymentUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteAdditionalPaymentUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();
            var fakeAdditionalPayments = FakeDbRepository.GetFakeAdditionalPayments();

            _fakeDbContext.Setup(set => set.AdditionalPayments).Returns(fakeAdditionalPayments.Object);
        }

        /// <summary>
        /// Тестирование удаления дополнительной выплаты
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteAdditionalPaymentTest()
        {
            // Arrange
            var command = new DeleteAdditionalPaymentRequestHandler(_fakeDbContext.Object);

            var fakeAdditionalPayment = _fakeDbContext.Object.AdditionalPayments.First();

            var request = new DeleteAdditionalPaymentRequest
            {
                AdditionalPayment = GetFakeDeleteAdditionalPaymentDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
                rec => rec.AdditionalPayments.Remove(It.IsAny<AdditionalPayment>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Дополнительная выплата"
        /// </summary>
        /// <param name="additionalPayment">Дополнительная выплата</param>
        /// <returns>DTO удаления "Дополнительная выплата"</returns>
        private static DeleteAdditionalPaymentDto GetFakeDeleteAdditionalPaymentDto()
        {
            return new DeleteAdditionalPaymentDto
            {
                Id = 1
            };
        }

    }
}
