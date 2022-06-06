using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.DeleteListMinimumSalary;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListMinimumSalaries.Commands.DeleteListMinimumSalary
{
    /// <summary>
    /// Тестирование команды "Удалить минимальную зарплату"
    /// </summary>
    public class DeleteListMinimumSalaryUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteListMinimumSalaryUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeMinimumSalaries = FakeDbRepository.GetFakeListMinimumSalaries();

            _fakeDbContext.Setup(set => set.ListMinimumSalaries).Returns(fakeMinimumSalaries.Object);
        }

        /// <summary>
        /// Тестирование удаления минимальной зарплаты
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteListMinimumSalaryTest()
        {
            // Arrang
            var command = new DeleteListMinimumSalaryRequestHandler(_fakeDbContext.Object);
            var request = new DeleteListMinimumSalaryRequest
            {
                MinimumSalary = GetDeleteListMinimumSalaryDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListMinimumSalaries.Remove(It.IsAny<ListMinimumSalary>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Минимальные зарплаты"
        /// </summary>
        /// <returns>DTO удаления "Минимальные зарплаты"</returns>
        private static DeleteListMinimumSalaryDto GetDeleteListMinimumSalaryDto()
        {
            return new DeleteListMinimumSalaryDto
            {
                Id = 1
            };
        }

    }
}
