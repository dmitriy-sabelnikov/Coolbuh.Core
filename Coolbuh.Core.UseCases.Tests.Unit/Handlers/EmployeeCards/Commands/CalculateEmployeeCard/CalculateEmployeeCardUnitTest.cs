using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.CalculateEmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.EmployeeCards.Commands.CalculateEmployeeCard
{
    /// <summary>
    /// Тестирование команды "Рассчитать карточку работника"
    /// </summary>
    public class CalculateEmployeeCardUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CalculateEmployeeCardUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
        }

        /// <summary>
        /// Тестирование расчета карточки работника
        /// </summary>
        [Fact]
        public async Task CalculateEmployeeCardTest()
        {
            // Arrange
            var sex = EmployeeCardSex.Male;
            var birthDate = new DateTime(2022, 05, 01);

            var fakeTaxIdentificationNumberService = new Mock<ITaxIdentificationNumberService>();
            fakeTaxIdentificationNumberService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));
            fakeTaxIdentificationNumberService.Setup(service => service.GetSex(It.IsAny<string>())).Returns(sex);
            fakeTaxIdentificationNumberService.Setup(service => service.GetBirthDate(It.IsAny<string>())).Returns(birthDate);

            var command = new CalculateEmployeeCardRequestHandler(fakeTaxIdentificationNumberService.Object);
            var request = new CalculateEmployeeCardRequest
            {
                EmployeeCard = GetCalculateEmployeeCardDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sex, result.Sex);
            Assert.Equal(birthDate, result.BirthDate);
        }

        /// <summary>
        /// Получить DTO "Рассчитать карточку работника"
        /// </summary>
        /// <returns>DTO "Рассчитать карточку работника"</returns>
        private static CalculateEmployeeCardDto GetCalculateEmployeeCardDto()
        {
            return new CalculateEmployeeCardDto
            {
                TaxIdentificationNumber = "1421406487"
            };
        }
    }
}
