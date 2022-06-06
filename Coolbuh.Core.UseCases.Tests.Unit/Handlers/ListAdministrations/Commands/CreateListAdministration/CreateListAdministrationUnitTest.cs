using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.CreateListAdministration;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListAdministrations.Commands.CreateListAdministration
{
    /// <summary>
    /// Тестирование команды "Создать администрацию"
    /// </summary>
    public class CreateListAdministrationUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListAdministrationUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeAdministrations = FakeDbRepository.GetFakeListAdministrations();
            var fakePositions = FakeDbRepository.GetFakeListPositions();

            _fakeDbContext.Setup(set => set.ListAdministrations).Returns(fakeAdministrations.Object);
            _fakeDbContext.Setup(set => set.ListPositions).Returns(fakePositions.Object);
        }

        /// <summary>
        /// Тестирование создания администрации
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateListAdministrationTest()
        {
            // Arrange
            var fakeAdministrationsService = new Mock<IListAdministrationsService>();
            fakeAdministrationsService.Setup(service => service.ValidationEntity(It.IsAny<ListAdministration>()));

            var command = new CreateListAdministrationRequestHandler(_fakeDbContext.Object, fakeAdministrationsService.Object);
            var request = new CreateListAdministrationRequest
            {
                Administration = GetCreateListAdministrationDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListAdministrations.AddAsync(It.IsAny<ListAdministration>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Администрации"
        /// </summary>
        /// <returns>DTO создания "Администрации"</returns>
        private static CreateListAdministrationDto GetCreateListAdministrationDto()
        {
            return new CreateListAdministrationDto
            {
                TaxIdentificationNumber = "3",
                FullName = "Кузьменко I.С.",
                TelephoneNumber = "123456",
                PositionId = 1
            };
        }
    }
}
