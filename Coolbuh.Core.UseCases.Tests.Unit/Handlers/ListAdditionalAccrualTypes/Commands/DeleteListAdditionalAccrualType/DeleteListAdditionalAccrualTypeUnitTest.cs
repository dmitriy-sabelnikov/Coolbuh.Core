using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.DeleteListAdditionalAccrualType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdditionalAccrualTypes.Commands.DeleteListAdditionalAccrualType
{
    /// <summary>
    /// Тестирование команды "Удалить тип дополнительных начислений"
    /// </summary>
    public class DeleteListAdditionalAccrualTypeUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListAdditionalAccrualTypeUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeListAdditionalAccrualTypes = FakeDbRepository.GetFakeListAdditionalAccrualTypes();

            _fakeDbContext.Setup(set => set.ListAdditionalAccrualTypes).Returns(fakeListAdditionalAccrualTypes.Object);
        }

        /// <summary>
        /// Тестирование удаления типа дополнительных начислений
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteListAdditionalAccrualTypeTest()
        {
            // Arrange
            var command = new DeleteListAdditionalAccrualTypeRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListAdditionalAccrualTypeRequest
            {
                AdditionalAccrualType = GetDeleteListAdditionalAccrualTypeDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListAdditionalAccrualTypes.Remove(It.IsAny<ListAdditionalAccrualType>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Типы дополнительных начислений"
        /// </summary>
        /// <returns>DTO удаления "Типы дополнительных начислений"</returns>
        private static DeleteListAdditionalAccrualTypeDto GetDeleteListAdditionalAccrualTypeDto()
        {
            return new DeleteListAdditionalAccrualTypeDto
            {
                Id = 1
            };
        }

    }
}
