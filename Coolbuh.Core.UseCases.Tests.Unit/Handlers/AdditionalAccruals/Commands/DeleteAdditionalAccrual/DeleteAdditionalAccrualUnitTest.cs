using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.DeleteAdditionalAccrual;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.AdditionalAccruals.Commands.DeleteAdditionalAccrual
{
    /// <summary>
    /// Тестирование команды "Удалить дополнительное начисление"
    /// </summary>
    public class DeleteAdditionalAccrualUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteAdditionalAccrualUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeAdditionalAccruals = FakeDbRepository.GetFakeAdditionalAccruals();

            _fakeDbContext.Setup(set => set.AdditionalAccruals).Returns(fakeAdditionalAccruals.Object);
        }

        /// <summary>
        /// Тестирование удаления дополнительного начисления
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteAdditionalAccrualTest()
        {
            // Arrange
            var command = new DeleteAdditionalAccrualRequestHandler(_fakeDbContext.Object);

            var fakeAdditionalAccrual = _fakeDbContext.Object.AdditionalAccruals.First();
            var additionalAccrualDto = GetFakeDeleteAdditionalAccrualDto(fakeAdditionalAccrual);

            var request = new DeleteAdditionalAccrualRequest
            {
                AdditionalAccrual = additionalAccrualDto
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
                rec => rec.AdditionalAccruals.Remove(It.IsAny<AdditionalAccrual>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Дополнительное начисление"
        /// </summary>
        /// <param name="additionalAccrual">Дополнительное начисление</param>
        /// <returns>DTO удаления "Дополнительное начисление"</returns>
        /// <exception cref="NullReferenceException"></exception>
        private static DeleteAdditionalAccrualDto GetFakeDeleteAdditionalAccrualDto(AdditionalAccrual additionalAccrual)
        {
            if (additionalAccrual == null) throw new NullReferenceException(nameof(additionalAccrual));

            return new DeleteAdditionalAccrualDto
            {
                Id = additionalAccrual.Id
            };
        }
    }
}
