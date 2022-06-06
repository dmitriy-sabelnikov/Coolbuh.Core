using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.CreateConsolidateReportCatalog;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ConsolidateReports.Commands.CreateConsolidateReportCatalog
{
    /// <summary>
    /// Тестирование команды "Создать каталог объединенной ведомости"
    /// </summary>
    public class CreateConsolidateReportCatalogUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateConsolidateReportCatalogUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeConsolidateReportCatalogs = FakeDbRepository.GetFakeConsolidateReportCatalogs();

            _fakeDbContext.Setup(set => set.ConsolidateReportCatalogs).Returns(fakeConsolidateReportCatalogs.Object);
        }

        /// <summary>
        /// Тестирование создания каталога объединенной ведомости
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateConsolidateReportCatalogTest()
        {
            // Arrange
            var fakeConsolidateReportsService = new Mock<IConsolidateReportsService>();
            fakeConsolidateReportsService.Setup(service => service.ValidationEntity(It.IsAny<ConsolidateReportCatalog>()));

            var command = new CreateConsolidateReportCatalogRequestHandler(_fakeDbContext.Object, fakeConsolidateReportsService.Object);
            var request = new CreateConsolidateReportCatalogRequest
            {
                ConsolidateReportCatalog = GetCreateConsolidateReportCatalogDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
               rec => rec.ConsolidateReportCatalogs.AddAsync(It.IsAny<ConsolidateReportCatalog>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Каталог объединенной ведомости"
        /// </summary>
        /// <returns>DTO создания "Каталог объединенной ведомости"</returns>
        private static CreateConsolidateReportCatalogDto GetCreateConsolidateReportCatalogDto()
        {
            return new CreateConsolidateReportCatalogDto
            {
                Quarter = 1,
                Year = 2022,
                Number = 1,
                Name = "Test",
                IsNoCalculate = false,
                IsAskAboutCalculate = false,
                IsCalculate = false
            };
        }
    }
}
