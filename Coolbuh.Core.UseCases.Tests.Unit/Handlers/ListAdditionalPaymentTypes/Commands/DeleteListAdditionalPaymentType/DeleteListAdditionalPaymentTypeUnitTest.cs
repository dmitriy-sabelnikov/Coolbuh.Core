using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.DeleteListAdditionalPaymentType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdditionalPaymentTypes.Commands.DeleteListAdditionalPaymentType
{
    /// <summary>
    /// Тестирование команды "Удалить тип дополнительных выплат"
    /// </summary>
    public class DeleteListAdditionalPaymentTypeUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListAdditionalPaymentTypeUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeListAdditionalPaymentTypes = FakeDbRepository.GetFakeListAdditionalPaymentTypes();

            _fakeDbContext.Setup(set => set.ListAdditionalPaymentTypes).Returns(fakeListAdditionalPaymentTypes.Object);
        }

        /// <summary>
        /// Тестирование удаления типа дополнительных выплат
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteListAdditionalPaymentTypeTest()
        {
            // Arrange
            var command = new DeleteListAdditionalPaymentTypeRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListAdditionalPaymentTypeRequest
            {
                AdditionalPaymentType = GetDeleteListAdditionalPaymentTypeDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListAdditionalPaymentTypes.Remove(It.IsAny<ListAdditionalPaymentType>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Типы дополнительных выплат"
        /// </summary>
        /// <returns></returns>
        private static DeleteListAdditionalPaymentTypeDto GetDeleteListAdditionalPaymentTypeDto()
        {
            return new DeleteListAdditionalPaymentTypeDto
            {
                Id = 1
            };
        }
    }
}
