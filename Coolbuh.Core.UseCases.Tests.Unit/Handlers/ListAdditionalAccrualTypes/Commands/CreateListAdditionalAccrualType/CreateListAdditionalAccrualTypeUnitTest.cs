using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.CreateListAdditionalAccrualType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdditionalAccrualTypes.Commands.CreateListAdditionalAccrualType
{
    /// <summary>
    /// Тестирование команды "Создать тип дополнительных начислений"
    /// </summary>
    public class CreateListAdditionalAccrualTypeUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListAdditionalAccrualTypeUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeListAdditionalAccrualTypes = FakeDbRepository.GetFakeListAdditionalAccrualTypes();

            _fakeDbContext.Setup(set => set.ListAdditionalAccrualTypes).Returns(fakeListAdditionalAccrualTypes.Object);
        }

        /// <summary>
        /// Тестирование создания типа дополнительных начислений
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateListAdditionalAccrualTypeTest()
        {
            // Arrange
            var fakeAdditionalAccrualTypesService = new Mock<IListAdditionalAccrualTypesService>();
            fakeAdditionalAccrualTypesService.Setup(service => service.ValidationEntity(It.IsAny<ListAdditionalAccrualType>()));

            var command = new CreateListAdditionalAccrualTypeRequestHandler(_fakeDbContext.Object, fakeAdditionalAccrualTypesService.Object);
            var request = new CreateListAdditionalAccrualTypeRequest
            {
                AdditionalAccrualType = GetCreateListAdditionalAccrualTypeDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListAdditionalAccrualTypes.AddAsync(It.IsAny<ListAdditionalAccrualType>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Типы дополнительных начислений"
        /// </summary>
        /// <returns>DTO создания "Типы дополнительных начислений"</returns>
        private static CreateListAdditionalAccrualTypeDto GetCreateListAdditionalAccrualTypeDto()
        {
            return new CreateListAdditionalAccrualTypeDto
            {
                Code = "10",
                Name = "Test",
                IsCalculate = true
            };
        }
    }
}
