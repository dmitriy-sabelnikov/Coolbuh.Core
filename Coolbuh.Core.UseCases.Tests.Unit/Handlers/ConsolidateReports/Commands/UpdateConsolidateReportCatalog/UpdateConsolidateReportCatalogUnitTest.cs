using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.UpdateConsolidateReportCatalog;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ConsolidateReports.Commands.UpdateConsolidateReportCatalog
{
    /// <summary>
    /// Тестирование команды "Обновить каталог объединенной ведомости"
    /// </summary>
    public class UpdateConsolidateReportCatalogUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateConsolidateReportCatalogUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeConsolidateReportCatalogs = FakeDbRepository.GetFakeConsolidateReportCatalogs();

            _fakeDbContext.Setup(set => set.ConsolidateReportCatalogs).Returns(fakeConsolidateReportCatalogs.Object);
        }

        /// <summary>
        /// Тестирование обновления каталога объединенной ведомости
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateConsolidateReportCatalogTest()
        {
            // Arrange
            var fakeConsolidateReportsService = new Mock<IConsolidateReportsService>();
            fakeConsolidateReportsService.Setup(service => service.ValidationEntity(It.IsAny<ConsolidateReportCatalog>()));

            var command = new UpdateConsolidateReportCatalogRequestHandler(_fakeDbContext.Object, fakeConsolidateReportsService.Object);
            var consolidateReportCatalog = GetUpdateConsolidateReportCatalogDto();

            var request = new UpdateConsolidateReportCatalogRequest
            {
                ConsolidateReportCatalog = consolidateReportCatalog
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
                   rec => rec.ConsolidateReportCatalogs.Update(It.IsAny<ConsolidateReportCatalog>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(consolidateReportCatalog.Id, result.Id);
            Assert.Equal(consolidateReportCatalog.Name, result.Name);
        }

        /// <summary>
        /// Получить DTO обновления "Каталог объединенной ведомости"
        /// </summary>
        /// <returns>DTO обновления "Каталог объединенной ведомости"</returns>
        private static UpdateConsolidateReportCatalogDto GetUpdateConsolidateReportCatalogDto()
        {
            return new UpdateConsolidateReportCatalogDto
            {
                Id = 1,
                Number = 1,
                Name = "Test",
                IsNoCalculate = false,
                IsAskAboutCalculate = false,
                IsCalculate = false
            };
        }
    }
}
