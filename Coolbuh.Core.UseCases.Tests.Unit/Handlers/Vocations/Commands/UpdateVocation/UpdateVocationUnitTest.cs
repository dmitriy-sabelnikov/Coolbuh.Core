using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Vocations.Commands.UpdateVocation;
using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Vocations.Commands.UpdateVocation
{
    /// <summary>
    /// Тестирование команды "Обновить отпуск"
    /// </summary>
    public class UpdateVocationUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateVocationUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();
            var fakeVocations = FakeDbRepository.GetFakeVocations();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
            _fakeDbContext.Setup(set => set.Vocations).Returns(fakeVocations.Object);
        }

        /// <summary>
        /// Тестирование обновления отпуска
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateVocationTest()
        {
            // Arrange
            var fakeVocationsService = new Mock<IVocationsService>();
            fakeVocationsService.Setup(service => service.ValidationEntity(It.IsAny<Vocation>()));

            var command = new UpdateVocationRequestHandler(_fakeDbContext.Object, fakeVocationsService.Object);
            var vocation = GetUpdateVocationDto();

            var request = new UpdateVocationRequest
            {
                Vocation = vocation
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.Vocations.Update(It.IsAny<Vocation>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(vocation.Id, result.Id);
            Assert.Equal(vocation.Sum, result.Sum);
        }

        /// <summary>
        /// Получить DTO обновления "Отпуск"
        /// </summary>
        /// <returns>DTO обновления "Отпуск"</returns>
        private static UpdateVocationDto GetUpdateVocationDto()
        {
            return new UpdateVocationDto
            {
                Id = 1,
                DepartmentId = 1,
                EmployeeCardId = 1,
                AccountingPeriod = new DateTime(2022, 07, 01),
                AccrualPeriod = new DateTime(2022, 07, 01),
                Days = 1,
                Sum = 1
            };
        }
    }
}
