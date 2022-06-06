using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.CreateListSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.ListSpecialSeniorities.Commands.CreateListSpecialSeniority
{
    /// <summary>
    /// Тестирование команды "Создать спецстаж"
    /// </summary>
    public class CreateListSpecialSeniorityUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateListSpecialSeniorityUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeSpecialSeniorities = FakeDbRepository.GetFakeListSpecialSeniorities();

            _fakeDbContext.Setup(set => set.ListSpecialSeniorities).Returns(fakeSpecialSeniorities.Object);
        }

        /// <summary>
        /// Тестирование создания спецстажа
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateListSpecialSeniorityTest()
        {
            // Arrange
            var fakeListSpecialSenioritiesService = new Mock<IListSpecialSenioritiesService>();
            fakeListSpecialSenioritiesService.Setup(service => service.ValidationEntity(It.IsAny<ListSpecialSeniority>()));

            var command = new CreateListSpecialSeniorityRequestHandler(_fakeDbContext.Object, fakeListSpecialSenioritiesService.Object);
            var request = new CreateListSpecialSeniorityRequest
            {
                SpecialSeniority = GetCreateListSpecialSeniorityDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.ListSpecialSeniorities.AddAsync(It.IsAny<ListSpecialSeniority>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Спецстажи"
        /// </summary>
        /// <returns>DTO создания "Спецстажи"</returns>
        private static CreateListSpecialSeniorityDto GetCreateListSpecialSeniorityDto()
        {
            return new CreateListSpecialSeniorityDto
            {
                Code = "3",
                ReasonCode = "123КДВ09",
                Name = "Плотник"
            };
        }
    }
}
