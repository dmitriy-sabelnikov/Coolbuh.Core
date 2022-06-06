using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.CreateListAdditionalPaymentType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdditionalPaymentTypes.Commands.CreateListAdditionalPaymentType
{
    /// <summary>
    /// Тестирование команды "Создать тип дополнительных выплат"
    /// </summary>
    public class CreateListAdditionalPaymentTypeUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListAdditionalPaymentTypeUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeListAdditionalPaymentTypes = FakeDbRepository.GetFakeListAdditionalPaymentTypes();

            _fakeDbContext.Setup(set => set.ListAdditionalPaymentTypes).Returns(fakeListAdditionalPaymentTypes.Object);
        }

        /// <summary>
        /// Тестирование создания типа дополнительных выплат
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateListAdditionalPaymentTypeTest()
        {
            // Arrange
            var fakeAdditionalPaymentTypesService = new Mock<IListAdditionalPaymentTypesService>();
            fakeAdditionalPaymentTypesService.Setup(service => service.ValidationEntity(It.IsAny<ListAdditionalPaymentType>()));

            var command = new CreateListAdditionalPaymentTypeRequestHandler(_fakeDbContext.Object, fakeAdditionalPaymentTypesService.Object);
            var request = new CreateListAdditionalPaymentTypeRequest
            {
                AdditionalPaymentType = GetCreateListAdditionalPaymentTypeDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListAdditionalPaymentTypes.AddAsync(It.IsAny<ListAdditionalPaymentType>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Типы дополнительных выплат"
        /// </summary>
        /// <returns></returns>
        private static CreateListAdditionalPaymentTypeDto GetCreateListAdditionalPaymentTypeDto()
        {
            return new CreateListAdditionalPaymentTypeDto
            {
                Code = "10",
                Name = "Test"
            };
        }
    }
}
