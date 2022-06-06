using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Coolbuh.Core.DomainServices.Tests.Unit
{
    /// <summary>
    /// Тестирование доменного сервиса "Карточка работника"
    /// </summary>
    public class EmployeeCardUnitTest
    {
        /// <summary>
        /// Валидация карточки работника - не указано имя
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutFirstNameTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            entity.FirstName = string.Empty;

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника - превышение допустимой длины имени
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalFirstNameLengthTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            entity.FirstName = new string('A', EmployeeCardConstants.FirstNameLength + 1);

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника - не указано отчество
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutMiddleNameTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            entity.MiddleName = string.Empty;

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника - превышение допустимой длины отчества
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalMiddleNameLengthTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            entity.MiddleName = new string('A', EmployeeCardConstants.MiddleNameLength + 1);

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника - не указана фамилия
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutLastNameTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            entity.LastName = string.Empty;

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника - превышение допустимой длины фамилии
        /// </summary>
        [Fact]
        public void ValidateEntityAbnormalLastNameLengthTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            entity.LastName = new string('A', EmployeeCardConstants.LastNameLength + 1);

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Список статусов - не указан тип статуса
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutCardStatusTypeTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var cardStatus = entity.EmployeeCardStatuses.First();
            cardStatus.CardStatusTypeId = 0;

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Список статусов - дата начала больше даты окончания периода
        /// </summary>
        [Fact]
        public void ValidateEntityCardStatusPeriodBeginMorePeriodEndTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var cardStatus = entity.EmployeeCardStatuses.First();
            cardStatus.PeriodBegin = new DateTime(2022, 05, 09);
            cardStatus.PeriodEnd = cardStatus.PeriodBegin.Value.AddDays(-1);

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Список статусов - дата начала больше даты окончания периода
        /// </summary>
        [Fact]
        public void ValidateEntityCardStatusExistsPeriodIntersectionTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var cardStatus = entity.EmployeeCardStatuses.First();
            entity.EmployeeCardStatuses.Add(new EmployeeCardStatus
            {
                Id = cardStatus.Id + 1,
                EmployeeCardId = cardStatus.EmployeeCardId,
                PeriodBegin = cardStatus.PeriodBegin,
                PeriodEnd = cardStatus.PeriodEnd,
                CardStatusTypeId = cardStatus.CardStatusTypeId
            });

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Инвалидность - не указан тип
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutDisabilityTypeTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var disability = entity.EmployeeDisabilities.First();
            disability.Type = 0;

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            //Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Инвалидность - дата начала больше даты окончания периода
        /// </summary>
        [Fact]
        public void ValidateEntityDisabilityBeginMorePeriodEndTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var disability = entity.EmployeeDisabilities.First();
            disability.PeriodBegin = new DateTime(2022, 05, 09);
            disability.PeriodEnd = disability.PeriodBegin.Value.AddDays(-1);

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            //Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Инвалидность - дата начала больше даты окончания периода
        /// </summary>
        [Fact]
        public void ValidateEntityDisabilityExistsPeriodIntersectionTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var disability = entity.EmployeeDisabilities.First();
            entity.EmployeeDisabilities.Add(new EmployeeDisability
            {
                Id = disability.Id + 1,
                EmployeeCardId = disability.EmployeeCardId,
                PeriodBegin = disability.PeriodBegin,
                PeriodEnd = disability.PeriodEnd,
                Type = disability.Type
            });

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            //Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Список детей - не указано количество детей
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutChildrenNumberTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var child = entity.EmployeeChildren.First();
            child.Number = 0;

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Список детей - дата начала больше даты окончания периода
        /// </summary>
        [Fact]
        public void ValidateEntityChildrenBeginMorePeriodEndTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var child = entity.EmployeeChildren.First();
            child.PeriodBegin = new DateTime(2022, 05, 09);
            child.PeriodEnd = child.PeriodBegin.Value.AddDays(-1);

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Список детей - дата начала больше даты окончания периода
        /// </summary>
        [Fact]
        public void ValidateEntityChildrenExistsPeriodIntersectionTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var child = entity.EmployeeChildren.First();
            entity.EmployeeChildren.Add(new EmployeeChildren
            {
                Id = child.Id + 1,
                EmployeeCardId = child.EmployeeCardId,
                PeriodBegin = child.PeriodBegin,
                PeriodEnd = child.PeriodEnd,
                Number = child.Number
            });

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Спецстаж - не указан тип спецстажа
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutSpecialSeniorityTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var specialSeniority = entity.EmployeeSpecialSeniorities.First();
            specialSeniority.SpecialSeniorityId = 0;

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Спецстаж - дата начала больше даты окончания периода
        /// </summary>
        [Fact]
        public void ValidateEntitySpecialSeniorityrenBeginMorePeriodEndTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var specialSeniority = entity.EmployeeSpecialSeniorities.First();
            specialSeniority.PeriodBegin = new DateTime(2022, 05, 09);
            specialSeniority.PeriodEnd = specialSeniority.PeriodBegin.Value.AddDays(-1);

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Спецстаж - дата начала больше даты окончания периода
        /// </summary>
        [Fact]
        public void ValidateEntitySpecialSeniorityrenExistsPeriodIntersectionTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var specialSeniority = entity.EmployeeSpecialSeniorities.First();
            entity.EmployeeSpecialSeniorities.Add(new EmployeeSpecialSeniority
            {
                Id = specialSeniority.Id + 1,
                EmployeeCardId = specialSeniority.EmployeeCardId,
                PeriodBegin = specialSeniority.PeriodBegin,
                PeriodEnd = specialSeniority.PeriodEnd,
                SpecialSeniorityId = specialSeniority.SpecialSeniorityId
            });

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Налоговая льгота - не указан тип коэффициент льготы
        /// </summary>
        [Fact]
        public void ValidateEntityWithoutTaxReliefTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var TaxRelief = entity.EmployeeTaxReliefs.First();
            TaxRelief.Сoefficient = 0;

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Налоговая льгота - дата начала больше даты окончания периода
        /// </summary>
        [Fact]
        public void ValidateEntityTaxReliefBeginMorePeriodEndTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var taxRelief = entity.EmployeeTaxReliefs.First();
            taxRelief.PeriodBegin = new DateTime(2022, 05, 09);
            taxRelief.PeriodEnd = taxRelief.PeriodBegin.Value.AddDays(-1);

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Валидация карточки работника. Налоговая льгота - дата начала больше даты окончания периода
        /// </summary>
        [Fact]
        public void ValidateEntityTaxReliefExistsPeriodIntersectionTest()
        {
            // Arrange
            var entity = GetFakeEmployeeCard();
            var taxRelief = entity.EmployeeTaxReliefs.First();
            entity.EmployeeTaxReliefs.Add(new EmployeeTaxRelief
            {
                Id = taxRelief.Id + 1,
                EmployeeCardId = taxRelief.EmployeeCardId,
                PeriodBegin = taxRelief.PeriodBegin,
                PeriodEnd = taxRelief.PeriodEnd,
                Сoefficient = taxRelief.Сoefficient
            });

            var mockTINService = new Mock<ITaxIdentificationNumberService>();
            mockTINService.Setup(service => service.ValidationTaxIdentificationNumber(It.IsAny<string>()));

            var service = new EmployeeCardsService(mockTINService.Object);

            // Act
            var result = Assert.Throws<NotValidEntityEntityException>(() => service.ValidationEntity(entity));

            // Assert
            Assert.NotEmpty(result.Message);
        }

        /// <summary>
        /// Получить фейковую карточку работника
        /// </summary>
        /// <returns>Фейковая карточка работника</returns>
        private static EmployeeCard GetFakeEmployeeCard()
        {
            return new EmployeeCard
            {
                Id = 1,
                FirstName = "Ivan",
                MiddleName = "Ivanovich",
                LastName = "Ivanov",
                TaxIdentificationNumber = "1421406487",
                Seniority = 1,
                Grade = 1,
                BirthDate = new DateTime(2022, 05, 09),
                EntryDate = new DateTime(2022, 05, 09),
                DismissalDate = new DateTime(2022, 05, 09),
                PensionDate = new DateTime(2022, 05, 09),
                Sex = EmployeeCardSex.Male,
                EmployeeCardStatuses = new List<EmployeeCardStatus>
                {
                    new EmployeeCardStatus
                    {
                        Id = 1,
                        EmployeeCardId = 1,
                        PeriodBegin = new DateTime(2022, 05, 01),
                        PeriodEnd = new DateTime(2022, 05, 01),
                        CardStatusTypeId = 1
                    }
                },
                EmployeeDisabilities = new List<EmployeeDisability>
                {
                    new EmployeeDisability
                    {
                        Id = 1,
                        EmployeeCardId = 1,
                        PeriodBegin = new DateTime(2022, 05, 01),
                        PeriodEnd = new DateTime(2022, 05, 01),
                        Type = 1
                    }
                },
                EmployeeChildren = new List<EmployeeChildren>
                {
                    new EmployeeChildren
                    {
                        Id = 1,
                        EmployeeCardId = 1,
                        PeriodBegin = new DateTime(2022, 05, 01),
                        PeriodEnd = new DateTime(2022, 05, 01),
                        Number = 1
                    }
                },
                EmployeeSpecialSeniorities = new List<EmployeeSpecialSeniority>
                {
                    new EmployeeSpecialSeniority
                    {
                        Id = 1,
                        EmployeeCardId = 1,
                        PeriodBegin = new DateTime(2022, 05, 01),
                        PeriodEnd = new DateTime(2022, 05, 01),
                        SpecialSeniorityId = 1
                    }
                },
                EmployeeTaxReliefs = new List<EmployeeTaxRelief>
                {
                    new EmployeeTaxRelief
                    {
                        Id = 1,
                        EmployeeCardId = 1,
                        PeriodBegin = new DateTime(2022, 05, 01),
                        PeriodEnd = new DateTime(2022, 05, 01),
                        Сoefficient = 1
                    }
                }
            };
        }
    }
}
