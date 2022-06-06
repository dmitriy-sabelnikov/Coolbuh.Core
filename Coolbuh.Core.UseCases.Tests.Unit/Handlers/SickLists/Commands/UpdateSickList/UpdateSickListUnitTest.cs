using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.SickLists.Commands.UpdateSickList;
using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.SickLists.Commands.UpdateSickList
{
    /// <summary>
    /// Тестирование команды "Обновить больничный лист"
    /// </summary>
    public class UpdateSickListUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateSickListUnitTest()
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
        /// Тестирование обновления больничного листа
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateSickListTest()
        {
            // Arrange
            var fakeSickListsService = new Mock<ISickListsService>();
            fakeSickListsService.Setup(service => service.ValidationEntity(It.IsAny<SickList>()));

            var command = new UpdateSickListRequestHandler(_fakeDbContext.Object, fakeSickListsService.Object);
            var request = new UpdateSickListRequest
            {
                SickList = GetUpdateSickListDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.SickLists.Update(It.IsAny<SickList>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.SickList.Id, result.Id);
            Assert.Equal(request.SickList.SocialInsuranceSum, result.SocialInsuranceSum);
        }

        /// <summary>
        /// Получить DTO обновления "Больничный лист"
        /// </summary>
        /// <returns>DTO обновления "Больничный лист"</returns>
        private static UpdateSickListDto GetUpdateSickListDto()
        {
            return new UpdateSickListDto
            {
                Id = 1,
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
