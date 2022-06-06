using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.CreateAdditionalAccrual;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.AdditionalAccruals.Commands.CreateAdditionalAccrual
{
    /// <summary>
    /// Тестирование команды "Создать дополнительное начисление"
    /// </summary>
    public class CreateAdditionalAccrualUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateAdditionalAccrualUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakeAdditionalAccrualTypes = FakeDbRepository.GetFakeListAdditionalAccrualTypes();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();
            var fakeAdditionalAccruals = FakeDbRepository.GetFakeAdditionalAccruals();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
            _fakeDbContext.Setup(set => set.ListAdditionalAccrualTypes).Returns(fakeAdditionalAccrualTypes.Object);
            _fakeDbContext.Setup(set => set.AdditionalAccruals).Returns(fakeAdditionalAccruals.Object);
        }

        /// <summary>
        /// Тестирование создания дополнительного начисления
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateAdditionalAccrualTest()
        {
            // Arrange
            var fakeAdditionalAccrualsService = new Mock<IAdditionalAccrualsService>();
            fakeAdditionalAccrualsService.Setup(service => service.ValidationEntity(It.IsAny<AdditionalAccrual>()));
            var command = new CreateAdditionalAccrualRequestHandler(_fakeDbContext.Object, fakeAdditionalAccrualsService.Object);

            var request = new CreateAdditionalAccrualRequest
            {
                AdditionalAccrual = GetFakeCreateAdditionalAccrualDto()
            };

            // Act 
            var result = await command.Handle(request, CancellationToken.None);

            //Assert
            _fakeDbContext.Verify(
                rec => rec.AdditionalAccruals.AddAsync(It.IsAny<AdditionalAccrual>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Дополнительное начисление" 
        /// </summary>
        /// <param name="employeeCard">Карточка работника</param>
        /// <param name="department">Подразделение</param>
        /// <param name="additionalAccrualType">Тип дополнительного начисления</param>
        /// <returns>DTO создания "Дополнительное начисление"</returns>
        private static CreateAdditionalAccrualDto GetFakeCreateAdditionalAccrualDto()
        {
            return new CreateAdditionalAccrualDto
            {
                EmployeeCardId = 1,
                DepartmentId = 1,
                AdditionalAccrualTypeId = 1,
                AccountingPeriod = new DateTime(2022, 05, 01),
                Sum = 1
            };
        }
    }
}
