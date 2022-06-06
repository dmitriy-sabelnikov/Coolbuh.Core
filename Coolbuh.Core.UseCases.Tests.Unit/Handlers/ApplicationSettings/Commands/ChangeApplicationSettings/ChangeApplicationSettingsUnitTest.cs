using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Commands.ChangeApplicationSettings;
using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ApplicationSettings.Commands.ChangeApplicationSettings
{
    /// <summary>
    /// Тестирование команды "Изменить параметры приложения"
    /// </summary>
    public class ChangeApplicationSettingsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public ChangeApplicationSettingsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeApplicationSettings = FakeDbRepository.GetFakeApplicationSettings();

            _fakeDbContext.Setup(set => set.ApplicationSettings).Returns(fakeApplicationSettings.Object);
        }

        /// <summary>
        /// Тестирование изменения параметров приложения
        /// </summary>
        [Fact]
        public async Task ChangeApplicationSettingsTest()
        {
            // Arrange
            var command = new ChangeApplicationSettingsRequestHandler(_fakeDbContext.Object);

            var request = new ChangeApplicationSettingsRequest()
            {
                ApplicationSetting = GetChangeApplicationSettingDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
                rec => rec.ApplicationSettings.UpdateRange(It.IsAny<List<ApplicationSetting>>()), Times.Once());
            _fakeDbContext.Verify(
                rec => rec.ApplicationSettings.RemoveRange(It.IsAny<List<ApplicationSetting>>()), Times.Once());

            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO изменения "Параметры приложения"
        /// </summary>
        /// <returns>DTO изменения "Параметры приложения"</returns>
        private static ChangeApplicationSettingDto GetChangeApplicationSettingDto()
        {
            return new ChangeApplicationSettingDto
            {
                AccountingYear = 2022,
                CompanyName = "Test"
            };
        }

    }
}
