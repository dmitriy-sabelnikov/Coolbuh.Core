using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.UpdateListAdditionalAccrualType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdditionalAccrualTypes.Commands.UpdateListAdditionalAccrualType
{
    /// <summary>
    /// Тестирование команды "Обновить тип дополнительных начислений"
    /// </summary>
    public class UpdateListAdditionalAccrualTypeUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListAdditionalAccrualTypeUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeListAdditionalAccrualTypes = FakeDbRepository.GetFakeListAdditionalAccrualTypes();

            _fakeDbContext.Setup(set => set.ListAdditionalAccrualTypes).Returns(fakeListAdditionalAccrualTypes.Object);
        }

        /// <summary>
        /// Тестирование обновления типа дополнительных начислений
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateListAdditionalAccrualTypeTest()
        {
            // Arrange
            var fakeAdditionalAccrualTypesService = new Mock<IListAdditionalAccrualTypesService>();
            fakeAdditionalAccrualTypesService.Setup(service => service.ValidationEntity(It.IsAny<ListAdditionalAccrualType>()));

            var command = new UpdateListAdditionalAccrualTypeRequestHandler(_fakeDbContext.Object, fakeAdditionalAccrualTypesService.Object);
            var request = new UpdateListAdditionalAccrualTypeRequest
            {
                AdditionalAccrualType = GetUpdateListAdditionalAccrualTypeDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListAdditionalAccrualTypes.Update(It.IsAny<ListAdditionalAccrualType>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.AdditionalAccrualType.Id, result.Id);
            Assert.Equal(request.AdditionalAccrualType.Name, result.Name);
        }

        /// <summary>
        /// Получить DTO обновления "Типы дополнительных начислений"
        /// </summary>
        /// <returns>DTO обновления "Типы дополнительных начислений"</returns>
        private static UpdateListAdditionalAccrualTypeDto GetUpdateListAdditionalAccrualTypeDto()
        {
            return new UpdateListAdditionalAccrualTypeDto
            {
                Id = 1,
                Code = "10",
                Name = "Test",
                IsCalculate = true
            };
        }
    }
}
