using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.DeleteConsolidateReportCatalog;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ConsolidateReports.Commands.DeleteConsolidateReportCatalog
{
    /// <summary>
    /// Тестирование команды "Удалить каталог объединенной ведомости"
    /// </summary>
    public class DeleteConsolidateReportCatalogUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public DeleteConsolidateReportCatalogUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeConsolidateReportCatalogs = FakeDbRepository.GetFakeConsolidateReportCatalogs();

            _fakeDbContext.Setup(set => set.ConsolidateReportCatalogs).Returns(fakeConsolidateReportCatalogs.Object);
        }

        /// <summary>
        /// Тестирование удаления каталога объединенной ведомости
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteConsolidateReportCatalogTest()
        {
            // Arrange
            var command = new DeleteConsolidateReportCatalogRequestHandler(_fakeDbContext.Object);
            var request = new DeleteConsolidateReportCatalogRequest
            {
                ConsolidateReportCatalog = GetDeleteConsolidateReportCatalogDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(
                   rec => rec.ConsolidateReportCatalogs.Remove(It.IsAny<ConsolidateReportCatalog>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO удаления "Каталог объединенной ведомости"
        /// </summary>
        /// <returns>DTO удаления "Каталог объединенной ведомости"</returns>
        private static DeleteConsolidateReportCatalogDto GetDeleteConsolidateReportCatalogDto()
        {
            return new DeleteConsolidateReportCatalogDto
            {
                Id = 1
            };
        }
    }
}
