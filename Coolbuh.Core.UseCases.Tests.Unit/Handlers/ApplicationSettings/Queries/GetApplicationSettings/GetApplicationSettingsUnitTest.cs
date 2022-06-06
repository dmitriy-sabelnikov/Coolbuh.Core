using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Queries.GetApplicationSettings;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ApplicationSettings.Queries.GetApplicationSettings
{
    /// <summary>
    /// Тестирование запроса "Получить параметры приложения"
    /// </summary>
    public class GetApplicationSettingsUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public GetApplicationSettingsUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeApplicationSettings = FakeDbRepository.GetFakeApplicationSettings();

            _fakeDbContext.Setup(set => set.ApplicationSettings).Returns(fakeApplicationSettings.Object);
        }

        /// <summary>
        /// Тестирование получения параметров приложения
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetApplicationSettingsTest()
        {
            // Arrange
            var companyUSREOU = _fakeDbContext.Object.ApplicationSettings
                .First(rec => rec.Type == ApplicationSettingType.CompanyUSREOU);
            var companyName = _fakeDbContext.Object.ApplicationSettings
                .First(rec => rec.Type == ApplicationSettingType.CompanyName);
            var accountingYear = _fakeDbContext.Object.ApplicationSettings
                .First(rec => rec.Type == ApplicationSettingType.AccountingYear);

            var command = new GetApplicationSettingsRequestHandler(_fakeDbContext.Object);
            var request = new GetApplicationSettingsRequest();

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(companyUSREOU.StringValue, result.CompanyUSREOU);
            Assert.Equal(companyName.StringValue, result.CompanyName);
            Assert.Equal(accountingYear.DigitValue, result.AccountingYear);
        }
    }
}
