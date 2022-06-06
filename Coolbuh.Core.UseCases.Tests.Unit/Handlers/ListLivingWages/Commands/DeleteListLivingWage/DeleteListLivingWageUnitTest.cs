using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.DeleteListLivingWage;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListLivingWages.Commands.DeleteListLivingWage
{
    /// <summary>
    /// Тестирование команды "Удалить прожиточный минимум"
    /// </summary>
    public class DeleteListLivingWageUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListLivingWageUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeLivingWages = FakeDbRepository.GetFakeListLivingWages();

            _fakeDbContext.Setup(set => set.ListLivingWages).Returns(fakeLivingWages.Object);
        }

        /// <summary>
        /// Тестирование удаления прожиточного минимума
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteListLivingWageTest()
        {
            // Arrange
            var command = new DeleteListLivingWageRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListLivingWageRequest
            {
                LivingWage = GetDeleteListMinimumSalaryDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListLivingWages.Remove(It.IsAny<ListLivingWage>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Прожиточные минимумы"
        /// </summary>
        /// <returns>DTO удаления "Прожиточные минимумы"</returns>
        private static DeleteListLivingWageDto GetDeleteListMinimumSalaryDto()
        {
            return new DeleteListLivingWageDto
            {
                Id = 1
            };
        }
    }
}
