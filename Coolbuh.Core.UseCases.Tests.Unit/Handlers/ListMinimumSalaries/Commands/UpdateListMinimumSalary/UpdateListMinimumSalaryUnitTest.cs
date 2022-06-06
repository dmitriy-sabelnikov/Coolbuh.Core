using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.UpdateListMinimumSalary;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListMinimumSalaries.Commands.UpdateListMinimumSalary
{
    /// <summary>
    /// Тестирование команды "Обновить минимальную зарплату"
    /// </summary>
    public class UpdateListMinimumSalaryUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListMinimumSalaryUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeMinimumSalaries = FakeDbRepository.GetFakeListMinimumSalaries();

            _fakeDbContext.Setup(set => set.ListMinimumSalaries).Returns(fakeMinimumSalaries.Object);
        }

        /// <summary>
        /// Тестирование обновления минимальной зарплаты
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateListMinimumSalaryTest()
        {
            // Arrang
            var fakeMinimumSalariesService = new Mock<IListMinimumSalariesService>();
            fakeMinimumSalariesService.Setup(service => service.ValidationEntity(It.IsAny<ListMinimumSalary>()));

            var command = new UpdateListMinimumSalaryRequestHandler(_fakeDbContext.Object, fakeMinimumSalariesService.Object);
            var request = new UpdateListMinimumSalaryRequest
            {
                MinimumSalary = GetUpdateListMinimumSalaryDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListMinimumSalaries.Update(It.IsAny<ListMinimumSalary>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.MinimumSalary.Id, result.Id);
            Assert.Equal(request.MinimumSalary.Sum, result.Sum);
        }

        /// <summary>
        /// Получить DTO обновления "Минимальные зарплаты"
        /// </summary>
        /// <returns>DTO обновления "Минимальные зарплаты"</returns>
        private static UpdateListMinimumSalaryDto GetUpdateListMinimumSalaryDto()
        {
            return new UpdateListMinimumSalaryDto
            {
                Id = 1,
                PeriodBegin = new DateTime(2022, 05, 01),
                PeriodEnd = new DateTime(2022, 06, 01),
                Sum = 100
            };
        }
    }
}
