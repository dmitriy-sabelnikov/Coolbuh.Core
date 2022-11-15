using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.CreateAdditionalPayment;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.AdditionalPayments.Commands.CreateAdditionalPayment
{
    /// <summary>
    /// Тестирование команды "Создать дополнительную выплату"
    /// </summary>
    public class CreateAdditionalPaymentUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateAdditionalPaymentUnitTest()
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
        /// Тестирование создания дополнительной выплаты
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateAdditionalPaymentTest()
        {
            // Arrange
            var fakeAdditionalPaymentsService = new Mock<IAdditionalPaymentsService>();
            fakeAdditionalPaymentsService.Setup(service => service.ValidationEntity(It.IsAny<AdditionalPayment>()));
            var command = new CreateAdditionalPaymentRequestHandler(_fakeDbContext.Object, fakeAdditionalPaymentsService.Object);

            var request = new CreateAdditionalPaymentRequest
            {
                AdditionalPayment = GetFakeCreateAdditionalPaymentDto()
            };

            // Act 
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
                rec => rec.AdditionalPayments.AddAsync(It.IsAny<AdditionalPayment>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Дополнительная выплата"
        /// </summary>
        /// <param name="employeeCard">Карточки работника</param>
        /// <param name="additionalPaymentType">Типы дополнительных выплат</param>
        /// <returns>DTO создания "Дополнительная выплата"</returns>
        private static CreateAdditionalPaymentDto GetFakeCreateAdditionalPaymentDto()
        {
            return new CreateAdditionalPaymentDto
            {
                EmployeeCardId = 1,
                AdditionalPaymentTypeId = 1,
                AccountingPeriod = new DateTime(2022, 05, 01),
                Sum = 1
            };
        }
    }
}
