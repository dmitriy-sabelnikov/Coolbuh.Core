using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.UpdateListAdministration;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdministrations.Commands.UpdateListAdministration
{
    /// <summary>
    /// Тестирование команды "Обновить администрацию"
    /// </summary>
    public class UpdateListAdministrationUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListAdministrationUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeAdministrations = FakeDbRepository.GetFakeListAdministrations();
            var fakePositions = FakeDbRepository.GetFakeListPositions();

            _fakeDbContext.Setup(set => set.ListAdministrations).Returns(fakeAdministrations.Object);
            _fakeDbContext.Setup(set => set.ListPositions).Returns(fakePositions.Object);
        }

        /// <summary>
        /// Тестирование обновления администрации
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateListAdministrationTest()
        {
            // Arrange
            var fakeAdministrationsService = new Mock<IListAdministrationsService>();
            fakeAdministrationsService.Setup(service => service.ValidationEntity(It.IsAny<ListAdministration>()));

            var command = new UpdateListAdministrationRequestHandler(_fakeDbContext.Object, fakeAdministrationsService.Object);
            var request = new UpdateListAdministrationRequest
            {
                Administration = GetUpdateListAdministrationDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListAdministrations.Update(It.IsAny<ListAdministration>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.Administration.Id, result.Id);
            Assert.Equal(request.Administration.FullName, result.FullName);
        }

        /// <summary>
        /// Получить DTO обновления "Администрации"
        /// </summary>
        /// <returns>DTO обновления "Администрации"</returns>
        private static UpdateListAdministrationDto GetUpdateListAdministrationDto()
        {
            return new UpdateListAdministrationDto
            {
                Id = 1,
                TaxIdentificationNumber = "3",
                FullName = "Кузьменко I.С.",
                TelephoneNumber = "123456",
                PositionId = 1
            };
        }
    }
}
