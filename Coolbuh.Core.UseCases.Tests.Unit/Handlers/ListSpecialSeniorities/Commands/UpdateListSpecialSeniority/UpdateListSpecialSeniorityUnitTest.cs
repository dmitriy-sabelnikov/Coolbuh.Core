using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.UpdateListSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListSpecialSeniorities.Commands.UpdateListSpecialSeniority
{
    /// <summary>
    /// Тестирование команды "Обновить спецстаж"
    /// </summary>
    public class UpdateListSpecialSeniorityUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateListSpecialSeniorityUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSpecialSeniorities = FakeDbRepository.GetFakeListSpecialSeniorities();

            _fakeDbContext.Setup(set => set.ListSpecialSeniorities).Returns(fakeSpecialSeniorities.Object);
        }

        /// <summary>
        /// Тестирование обновления спецстажа
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateListSpecialSeniorityTest()
        {
            // Arrange
            var fakeListSpecialSenioritiesService = new Mock<IListSpecialSenioritiesService>();
            fakeListSpecialSenioritiesService.Setup(service => service.ValidationEntity(It.IsAny<ListSpecialSeniority>()));

            var command = new UpdateListSpecialSeniorityRequestHandler(_fakeDbContext.Object, fakeListSpecialSenioritiesService.Object);
            var request = new UpdateListSpecialSeniorityRequest
            {
                SpecialSeniority = GetUpdateListSpecialSeniorityDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListSpecialSeniorities.Update(It.IsAny<ListSpecialSeniority>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.SpecialSeniority.Id, result.Id);
            Assert.Equal(request.SpecialSeniority.Name, result.Name);
        }

        /// <summary>
        /// Получить DTO обновления "Спецстажи"
        /// </summary>
        /// <returns>DTO обновления "Спецстажи"</returns>
        private static UpdateListSpecialSeniorityDto GetUpdateListSpecialSeniorityDto()
        {
            return new UpdateListSpecialSeniorityDto
            {
                Id = 1,
                Code = "3",
                ReasonCode = "123КДВ09",
                Name = "Плотник"
            };
        }
    }
}
