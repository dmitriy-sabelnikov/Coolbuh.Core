using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.UpdateListAdditionalPaymentType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdditionalPaymentTypes.Commands.UpdateListAdditionalPaymentType
{
    /// <summary>
    /// Тестирование команды "Обновить тип дополнительных выплат"
    /// </summary>
    public class UpdateListAdditionalPaymentTypeUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListAdditionalPaymentTypeUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeListAdditionalPaymentTypes = FakeDbRepository.GetFakeListAdditionalPaymentTypes();

            _fakeDbContext.Setup(set => set.ListAdditionalPaymentTypes).Returns(fakeListAdditionalPaymentTypes.Object);
        }

        /// <summary>
        /// Тестирование обновления типа дополнительных выплат
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateListAdditionalPaymentTypeTest()
        {
            // Arrange
            var fakeAdditionalPaymentTypesService = new Mock<IListAdditionalPaymentTypesService>();
            fakeAdditionalPaymentTypesService.Setup(service => service.ValidationEntity(It.IsAny<ListAdditionalPaymentType>()));

            var command = new UpdateListAdditionalPaymentTypeRequestHandler(_fakeDbContext.Object, fakeAdditionalPaymentTypesService.Object);
            var request = new UpdateListAdditionalPaymentTypeRequest
            {
                AdditionalPaymentType = GetUpdateListAdditionalPaymentTypeDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListAdditionalPaymentTypes.Update(It.IsAny<ListAdditionalPaymentType>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.AdditionalPaymentType.Id, result.Id);
            Assert.Equal(request.AdditionalPaymentType.Name, result.Name);
        }

        /// <summary>
        /// Получить DTO обновления "Типы дополнительных выплат"
        /// </summary>
        /// <returns></returns>
        private static UpdateListAdditionalPaymentTypeDto GetUpdateListAdditionalPaymentTypeDto()
        {
            return new UpdateListAdditionalPaymentTypeDto
            {
                Id = 1,
                Code = "10",
                Name = "Test"
            };
        }

    }
}
