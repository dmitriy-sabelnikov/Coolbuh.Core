using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.SickLists.Commands.CreateSickList;
using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.SickLists.Commands.CreateSickList
{
    /// <summary>
    /// Тестирование команды "Создать больничный лист"
    /// </summary>
    public class CreateSickListUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateSickListUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakeDepartments = FakeDbRepository.GetFakeListDepartments();
            var fakeSickLists = FakeDbRepository.GetFakeSickLists();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.ListDepartments).Returns(fakeDepartments.Object);
            _fakeDbContext.Setup(set => set.SickLists).Returns(fakeSickLists.Object);
        }

        /// <summary>
        /// Тестирование создания больничного листа
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateSickListTest()
        {
            // Arrange
            var fakeSickListsService = new Mock<ISickListsService>();
            fakeSickListsService.Setup(service => service.ValidationEntity(It.IsAny<SickList>()));

            var command = new CreateSickListRequestHandler(_fakeDbContext.Object, fakeSickListsService.Object);
            var request = new CreateSickListRequest
            {
                SickList = GetCreateSickListDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.SickLists.AddAsync(It.IsAny<SickList>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Больничный лист"
        /// </summary>
        /// <returns>DTO создания "Больничный лист"</returns>
        private static CreateSickListDto GetCreateSickListDto()
        {
            return new CreateSickListDto
            {
                EmployeeCardId = 1,
                DepartmentId = 1,
                AccountingPeriod = new DateTime(2022, 06, 01),
                AccrualPeriod = new DateTime(2022, 06, 01),
                EnterpriseDays = 2,
                EnterpriseSum = 10,
                SocialInsuranceDays = 4,
                SocialInsuranceSum = 20
            };
        }
    }
}
