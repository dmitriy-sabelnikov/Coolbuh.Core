using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.CreateEmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCardStatus;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeChildren;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeDisability;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeTaxRelief;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.EmployeeCards.Commands.CreateEmployeeCard
{
    /// <summary>
    /// Тестирование команды "Создать карточку работника"
    /// </summary>
    public class CreateEmployeeCardUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public CreateEmployeeCardUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
        }

        /// <summary>
        /// Тестирование создания карточки работника
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateEmployeeCardTest()
        {
            // Arrange
            var fakeEmployeeCardsService = new Mock<IEmployeeCardsService>();
            fakeEmployeeCardsService.Setup(service => service.ValidationEntity(It.IsAny<EmployeeCard>()));

            var command = new CreateEmployeeCardRequestHandler(_fakeDbContext.Object, fakeEmployeeCardsService.Object);
            var request = new CreateEmployeeCardRequest
            {
                EmployeeCard = GetCreateEmployeeCardDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.EmployeeCards.AddAsync(It.IsAny<EmployeeCard>(), CancellationToken.None), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
        }

        /// <summary>
        /// Получить DTO создания "Карточка работника"
        /// </summary>
        /// <returns>DTO создания "Карточка работника"</returns>
        private static CreateEmployeeCardDto GetCreateEmployeeCardDto()
        {
            return new CreateEmployeeCardDto
            {
                FirstName = "НIНА",
                MiddleName = "ПРОКОПIВНА",
                LastName = "ГРЕБIННИК",
                TaxIdentificationNumber = "1923409741",
                Seniority = 1,
                Grade = 1,
                BirthDate = new DateTime(2000, 05, 01),
                EntryDate = new DateTime(2020, 05, 01),
                Sex = EmployeeCardSex.Male,
                EmployeeChildren = new List<CreateEmployeeChildrenDto>
                {
                    new CreateEmployeeChildrenDto
                    {
                        Number = 1
                    }
                },
                EmployeeDisabilities = new List<CreateEmployeeDisabilityDto>
                {
                    new CreateEmployeeDisabilityDto
                    {
                        Type = 1
                    }
                },
                EmployeeCardStatuses = new List<CreateEmployeeCardStatusDto>
                {
                    new CreateEmployeeCardStatusDto
                    {
                        CardStatusTypeId = 1
                    }
                },
                EmployeeSpecialSeniorities = new List<CreateEmployeeSpecialSeniorityDto>
                {
                    new CreateEmployeeSpecialSeniorityDto
                    {
                        SpecialSeniorityId = 1
                    }
                },
                EmployeeTaxReliefs = new List<CreateEmployeeTaxReliefDto>
                {
                    new CreateEmployeeTaxReliefDto
                    {
                        Сoefficient = 1
                    }
                }
            };
        }
    }
}
