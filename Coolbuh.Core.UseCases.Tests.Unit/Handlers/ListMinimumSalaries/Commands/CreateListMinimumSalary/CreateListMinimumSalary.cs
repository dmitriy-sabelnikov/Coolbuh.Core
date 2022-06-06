using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.CreateListMinimumSalary;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListMinimumSalaries.Commands.CreateListMinimumSalary
{
    /// <summary>
    /// Тестирование команды "Создать минимальную зарплату"
    /// </summary>
    public class CreateListMinimumSalary
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListMinimumSalary()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeMinimumSalaries = FakeDbRepository.GetFakeListMinimumSalaries();

            _fakeDbContext.Setup(set => set.ListMinimumSalaries).Returns(fakeMinimumSalaries.Object);
        }

        /// <summary>
        /// Тестирование создания минимальной зарплаты
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateListMinimumSalaryTest()
        {
            // Arrang
            var fakeMinimumSalariesService = new Mock<IListMinimumSalariesService>();
            fakeMinimumSalariesService.Setup(service => service.ValidationEntity(It.IsAny<ListMinimumSalary>()));

            var command = new CreateListMinimumSalaryRequestHandler(_fakeDbContext.Object, fakeMinimumSalariesService.Object);
            var request = new CreateListMinimumSalaryRequest
            {
                MinimumSalary = GetCreateListMinimumSalaryDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListMinimumSalaries.AddAsync(It.IsAny<ListMinimumSalary>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Минимальные зарплаты"
        /// </summary>
        /// <returns>DTO создания "Минимальные зарплаты"</returns>
        private static CreateListMinimumSalaryDto GetCreateListMinimumSalaryDto()
        {
            return new CreateListMinimumSalaryDto
            {
                PeriodBegin = new DateTime(2022, 05, 01),
                PeriodEnd = new DateTime(2022, 06, 01),
                Sum = 100
            };
        }
    }
}
