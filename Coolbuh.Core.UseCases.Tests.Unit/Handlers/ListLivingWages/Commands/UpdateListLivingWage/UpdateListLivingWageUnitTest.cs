using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.UpdateListLivingWage;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListLivingWages.Commands.UpdateListLivingWage
{
    /// <summary>
    /// Тестирование команды "Обновить прожиточный минимум"
    /// </summary>
    public class UpdateListLivingWageUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListLivingWageUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeLivingWages = FakeDbRepository.GetFakeListLivingWages();

            _fakeDbContext.Setup(set => set.ListLivingWages).Returns(fakeLivingWages.Object);
        }

        /// <summary>
        /// Тестирование обновления прожиточного минимума
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateListLivingWageTest()
        {
            // Arrange
            var fakeLivingWagesService = new Mock<IListLivingWagesService>();
            fakeLivingWagesService.Setup(service => service.ValidationEntity(It.IsAny<ListLivingWage>()));

            var command = new UpdateListLivingWageRequestHandler(_fakeDbContext.Object, fakeLivingWagesService.Object);
            var request = new UpdateListLivingWageRequest
            {
                LivingWage = GetUpdateListMinimumSalaryDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListLivingWages.Update(It.IsAny<ListLivingWage>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.LivingWage.Id, result.Id);
            Assert.Equal(request.LivingWage.Sum, result.Sum);
        }

        /// <summary>
        /// Получить DTO обновления "Прожиточные минимумы"
        /// </summary>
        /// <returns>DTO обновления "Прожиточные минимумы"</returns>
        private static UpdateListLivingWageDto GetUpdateListMinimumSalaryDto()
        {
            return new UpdateListLivingWageDto
            {
                Id = 1,
                PeriodBegin = new DateTime(2022, 05, 01),
                PeriodEnd = new DateTime(2022, 06, 01),
                Sum = 100
            };
        }
    }
}
