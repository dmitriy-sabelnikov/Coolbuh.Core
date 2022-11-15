using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.UpdateEmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCardStatus;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeChildren;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeDisability;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeTaxRelief;
using Moq;
using Xunit;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers.EmployeeCards.Commands.UpdateEmployeeCard
{
    /// <summary>
    /// Тестирование команды "Обновить карточку работника"
    /// </summary>
    public class UpdateEmployeeCardUnitTest
    {
        private readonly Mock<IDbContext> _fakeDbContext;

        public UpdateEmployeeCardUnitTest()
        {
            _fakeDbContext = FakeDbRepository.GetFakeDbContext();

            var fakeEmployeeCards = FakeDbRepository.GetFakeEmployeeCards();
            var fakeEmployeeCardStatuses = FakeDbRepository.GetFakeEmployeeCardStatuses();
            var fakeEmployeeChildren = FakeDbRepository.GetFakeEmployeeChildren();
            var fakeEmployeeDisabilities = FakeDbRepository.GetFakeEmployeeDisabilities();
            var fakeEmployeeSpecialSeniorities = FakeDbRepository.GetFakeEmployeeSpecialSeniorities();
            var fakeEmployeeTaxReliefs = FakeDbRepository.GetFakeEmployeeTaxReliefs();

            _fakeDbContext.Setup(set => set.EmployeeCards).Returns(fakeEmployeeCards.Object);
            _fakeDbContext.Setup(set => set.EmployeeCardStatuses).Returns(fakeEmployeeCardStatuses.Object);
            _fakeDbContext.Setup(set => set.EmployeeChildren).Returns(fakeEmployeeChildren.Object);
            _fakeDbContext.Setup(set => set.EmployeeDisabilities).Returns(fakeEmployeeDisabilities.Object);
            _fakeDbContext.Setup(set => set.EmployeeSpecialSeniorities).Returns(fakeEmployeeSpecialSeniorities.Object);
            _fakeDbContext.Setup(set => set.EmployeeTaxReliefs).Returns(fakeEmployeeTaxReliefs.Object);
        }

        /// <summary>
        /// Тестирование обновления карточки работника
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateEmployeeCardTest()
        {
            // Arrange
            var fakeEmployeeCardsService = new Mock<IEmployeeCardsService>();
            fakeEmployeeCardsService.Setup(service => service.ValidationEntity(It.IsAny<EmployeeCard>()));

            var command = new UpdateEmployeeCardRequestHandler(_fakeDbContext.Object, fakeEmployeeCardsService.Object);
            var request = new UpdateEmployeeCardRequest
            {
                EmployeeCard = GetUpdateEmployeeCardDto()
            };

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            _fakeDbContext.Verify(rec => rec.EmployeeCards.Update(It.IsAny<EmployeeCard>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.EmployeeCardStatuses.RemoveRange(It.IsAny<List<EmployeeCardStatus>>()), Times.Once());
            _fakeDbContext.Verify(rec => rec.SaveChangesAsync(CancellationToken.None), Times.Once());

            Assert.NotNull(result);
            Assert.Equal(request.EmployeeCard.Id, result.Id);
            Assert.Equal(request.EmployeeCard.FirstName, result.FirstName);
            Assert.Equal(request.EmployeeCard.EmployeeChildren.Count, result.EmployeeChildren.Count);
            Assert.Equal(request.EmployeeCard.EmployeeDisabilities.Count, result.EmployeeDisabilities.Count);
            Assert.Equal(request.EmployeeCard.EmployeeCardStatuses.Count, result.EmployeeCardStatuses.Count);
            Assert.Equal(request.EmployeeCard.EmployeeSpecialSeniorities.Count, result.EmployeeSpecialSeniorities.Count);
            Assert.Equal(request.EmployeeCard.EmployeeTaxReliefs.Count, result.EmployeeTaxReliefs.Count);
        }

        /// <summary>
        /// Получить DTO обновления "Карточка работника"
        /// </summary>
        /// <returns>DTO обновления "Карточка работника"</returns>
        private static UpdateEmployeeCardDto GetUpdateEmployeeCardDto()
        {
            return new UpdateEmployeeCardDto
            {
                Id = 1,
                FirstName = "НIНА",
                MiddleName = "ПРОКОПIВНА",
                LastName = "ГРЕБIННИК",
                TaxIdentificationNumber = "1923409741",
                Seniority = 1,
                Grade = 1,
                BirthDate = new DateTime(2000, 05, 01),
                EntryDate = new DateTime(2020, 05, 01),
                Sex = EmployeeCardSex.Male,
                EmployeeChildren = new List<UpdateEmployeeChildrenDto>
                {
                    new UpdateEmployeeChildrenDto
                    {
                        Number = 1
                    }
                },
                EmployeeDisabilities = new List<UpdateEmployeeDisabilityDto>
                {
                    new UpdateEmployeeDisabilityDto
                    {
                        Type = 1
                    }
                },
                EmployeeCardStatuses = new List<UpdateEmployeeCardStatusDto>
                {
                    new UpdateEmployeeCardStatusDto
                    {
                        CardStatusTypeId = 1
                    }
                },
                EmployeeSpecialSeniorities = new List<UpdateEmployeeSpecialSeniorityDto>
                {
                    new UpdateEmployeeSpecialSeniorityDto
                    {
                        SpecialSeniorityId = 1
                    }
                },
                EmployeeTaxReliefs = new List<UpdateEmployeeTaxReliefDto>
                {
                    new UpdateEmployeeTaxReliefDto
                    {
                        Сoefficient = 1
                    }
                }
            };
        }
    }
}
