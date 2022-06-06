using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Vocations.Commands.CreateVocation;
using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.Vocations.Commands.CreateVocation
{
    /// <summary>
    /// Тестирование команды "Создать отпуск"
    /// </summary>
    public class CreateVocationUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateVocationUnitTest()
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
        /// Тестирование создания отпуска
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateVocationTest()
        {
            // Arrange
            var fakeVocationsService = new Mock<IVocationsService>();
            fakeVocationsService.Setup(service => service.ValidationEntity(It.IsAny<Vocation>()));

            var command = new CreateVocationRequestHandler(_fakeDbContext.Object, fakeVocationsService.Object);
            var request = new CreateVocationRequest
            {
                Vocation = GetCreateVocationDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
               rec => rec.Vocations.AddAsync(It.IsAny<Vocation>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Отпуск"
        /// </summary>
        /// <returns>DTO создания "Отпуск"</returns>
        private static CreateVocationDto GetCreateVocationDto()
        {
            return new CreateVocationDto
            {
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
