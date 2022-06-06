using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCardStatus;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeChildren;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeDisability;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeTaxRelief;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Extensions
{
    /// <summary>
    /// Методы расширения карточки работника
    /// </summary>
    public static class EmployeeCardExtension
    {
        /// <summary>
        /// Маппинг карточки работника
        /// </summary>
        /// <param name="dto">DTO создания "Карточка работника"</param>
        /// <returns>Карточка работника</returns>
        public static EmployeeCard MapEmployeeCard(this CreateEmployeeCardDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            List<EmployeeChildren> employeeChildren = null;
            List<EmployeeTaxRelief> employeeTaxReliefs = null;
            List<EmployeeCardStatus> employeeCardStatuses = null;
            List<EmployeeDisability> employeeDisabilities = null;
            List<EmployeeSpecialSeniority> employeeSpecialSeniorities = null;

            if (dto.EmployeeChildren != null)
            {
                employeeChildren = new List<EmployeeChildren>();

                foreach (var children in dto.EmployeeChildren)
                    employeeChildren.Add(children.MapEmployeeChildren());
            }

            if (dto.EmployeeTaxReliefs != null)
            {
                employeeTaxReliefs = new List<EmployeeTaxRelief>();

                foreach (var taxRelief in dto.EmployeeTaxReliefs)
                    employeeTaxReliefs.Add(taxRelief.MapEmployeeTaxRelief());
            }

            if (dto.EmployeeCardStatuses != null)
            {
                employeeCardStatuses = new List<EmployeeCardStatus>();

                foreach (var cardStatus in dto.EmployeeCardStatuses)
                    employeeCardStatuses.Add(cardStatus.MapEmployeeCardStatus());
            }

            if (dto.EmployeeDisabilities != null)
            {
                employeeDisabilities = new List<EmployeeDisability>();

                foreach (var disability in dto.EmployeeDisabilities)
                    employeeDisabilities.Add(disability.MapEmployeeDisability());
            }

            if (dto.EmployeeSpecialSeniorities != null)
            {
                employeeSpecialSeniorities = new List<EmployeeSpecialSeniority>();

                foreach (var specialSeniority in dto.EmployeeSpecialSeniorities)
                    employeeSpecialSeniorities.Add(specialSeniority.MapEmployeeSpecialSeniority());
            }

            return new EmployeeCard
            {
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                TaxIdentificationNumber = dto.TaxIdentificationNumber,
                Seniority = dto.Seniority,
                Grade = dto.Grade,
                BirthDate = dto.BirthDate,
                EntryDate = dto.EntryDate,
                DismissalDate = dto.DismissalDate,
                PensionDate = dto.PensionDate,
                Sex = dto.Sex,
                EmployeeChildren = employeeChildren,
                EmployeeTaxReliefs = employeeTaxReliefs,
                EmployeeCardStatuses = employeeCardStatuses,
                EmployeeDisabilities = employeeDisabilities,
                EmployeeSpecialSeniorities = employeeSpecialSeniorities
            };
        }

        /// <summary>
        /// Маппинг карточки работника
        /// </summary>
        /// <param name="dto">DTO обновления "Карточка работника"</param>
        /// <returns>Карточка работника</returns>
        public static EmployeeCard MapEmployeeCard(this UpdateEmployeeCardDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            List<EmployeeChildren> employeeChildren = null;
            List<EmployeeTaxRelief> employeeTaxReliefs = null;
            List<EmployeeCardStatus> employeeCardStatuses = null;
            List<EmployeeDisability> employeeDisabilities = null;
            List<EmployeeSpecialSeniority> employeeSpecialSeniorities = null;

            if (dto.EmployeeChildren != null)
            {
                employeeChildren = new List<EmployeeChildren>();

                foreach (var children in dto.EmployeeChildren)
                    employeeChildren.Add(children.MapEmployeeChildren());
            }

            if (dto.EmployeeTaxReliefs != null)
            {
                employeeTaxReliefs = new List<EmployeeTaxRelief>();

                foreach (var taxRelief in dto.EmployeeTaxReliefs)
                    employeeTaxReliefs.Add(taxRelief.MapEmployeeTaxRelief());
            }

            if (dto.EmployeeCardStatuses != null)
            {
                employeeCardStatuses = new List<EmployeeCardStatus>();

                foreach (var cardStatus in dto.EmployeeCardStatuses)
                    employeeCardStatuses.Add(cardStatus.MapEmployeeCardStatus());
            }

            if (dto.EmployeeDisabilities != null)
            {
                employeeDisabilities = new List<EmployeeDisability>();

                foreach (var disability in dto.EmployeeDisabilities)
                    employeeDisabilities.Add(disability.MapEmployeeDisability());
            }

            if (dto.EmployeeSpecialSeniorities != null)
            {
                employeeSpecialSeniorities = new List<EmployeeSpecialSeniority>();

                foreach (var specialSeniority in dto.EmployeeSpecialSeniorities)
                    employeeSpecialSeniorities.Add(specialSeniority.MapEmployeeSpecialSeniority());
            }

            return new EmployeeCard
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                TaxIdentificationNumber = dto.TaxIdentificationNumber,
                Seniority = dto.Seniority,
                Grade = dto.Grade,
                BirthDate = dto.BirthDate,
                EntryDate = dto.EntryDate,
                DismissalDate = dto.DismissalDate,
                PensionDate = dto.PensionDate,
                Sex = dto.Sex,
                EmployeeChildren = employeeChildren,
                EmployeeTaxReliefs = employeeTaxReliefs,
                EmployeeCardStatuses = employeeCardStatuses,
                EmployeeDisabilities = employeeDisabilities,
                EmployeeSpecialSeniorities = employeeSpecialSeniorities
            };
        }

        /// <summary>
        /// Маппинг детей работника 
        /// </summary>
        /// <param name="dto">DTO создания "Дети"</param>
        /// <returns>Дети работника</returns>
        public static EmployeeChildren MapEmployeeChildren(this CreateEmployeeChildrenDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new EmployeeChildren
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Number = dto.Number
            };
        }

        /// <summary>
        /// Маппинг детей работника 
        /// </summary>
        /// <param name="dto">DTO обновления "Дети"</param>
        /// <returns>Дети работника</returns>
        public static EmployeeChildren MapEmployeeChildren(this UpdateEmployeeChildrenDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new EmployeeChildren
            {
                Id = dto.Id,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Number = dto.Number
            };
        }

        /// <summary>
        /// Маппинг детей работника 
        /// </summary>
        /// <param name="children">Дети работника</param>
        /// <returns>DTO "Дети"</returns>
        public static EmployeeChildrenDto MapEmployeeChildren(this EmployeeChildren children)
        {
            if (children == null) throw new NullReferenceException(nameof(children));

            return new EmployeeChildrenDto
            {
                Id = children.Id,
                PeriodBegin = children.PeriodBegin,
                PeriodEnd = children.PeriodEnd,
                Number = children.Number
            };
        }

        /// <summary>
        /// Маппинг налоговой льготы
        /// </summary>
        /// <param name="dto">DTO создания "Налоговая льгота"</param>
        /// <returns>Налоговая льгота</returns>
        public static EmployeeTaxRelief MapEmployeeTaxRelief(this CreateEmployeeTaxReliefDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new EmployeeTaxRelief
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Сoefficient = dto.Сoefficient
            };
        }

        /// <summary>
        /// Маппинг налоговой льготы
        /// </summary>
        /// <param name="dto">DTO обновления "Налоговая льгота"</param>
        /// <returns>Налоговая льгота</returns>
        public static EmployeeTaxRelief MapEmployeeTaxRelief(this UpdateEmployeeTaxReliefDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new EmployeeTaxRelief
            {
                Id = dto.Id,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Сoefficient = dto.Сoefficient
            };
        }

        /// <summary>
        /// Маппинг налоговой льготы
        /// </summary>
        /// <param name="taxRelief">Налоговая льгота</param>
        /// <returns>DTO "Налоговая льгота"</returns>
        public static EmployeeTaxReliefDto MapEmployeeTaxRelief(this EmployeeTaxRelief taxRelief)
        {
            if (taxRelief == null) throw new NullReferenceException(nameof(taxRelief));

            return new EmployeeTaxReliefDto
            {
                Id = taxRelief.Id,
                PeriodBegin = taxRelief.PeriodBegin,
                PeriodEnd = taxRelief.PeriodEnd,
                Сoefficient = taxRelief.Сoefficient
            };
        }

        /// <summary>
        /// Маппинг статуса работника
        /// </summary>
        /// <param name="dto">DTO создания "Статус"</param>
        /// <returns>Статус работника</returns>
        public static EmployeeCardStatus MapEmployeeCardStatus(this CreateEmployeeCardStatusDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new EmployeeCardStatus
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                CardStatusTypeId = dto.CardStatusTypeId
            };
        }

        /// <summary>
        /// Маппинг статуса работника
        /// </summary>
        /// <param name="dto">DTO обновления "Статус"</param>
        /// <returns>Статус работника</returns>
        public static EmployeeCardStatus MapEmployeeCardStatus(this UpdateEmployeeCardStatusDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new EmployeeCardStatus
            {
                Id = dto.Id,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                CardStatusTypeId = dto.CardStatusTypeId
            };
        }

        /// <summary>
        /// Маппинг статуса работника
        /// </summary>
        /// <param name="cardStatus">Статус работника</param>
        /// <returns>DTO "Статус"</returns>
        public static EmployeeCardStatusDto MapEmployeeCardStatus(this EmployeeCardStatus cardStatus)
        {
            if (cardStatus == null) throw new NullReferenceException(nameof(cardStatus));

            return new EmployeeCardStatusDto
            {
                Id = cardStatus.Id,
                PeriodBegin = cardStatus.PeriodBegin,
                PeriodEnd = cardStatus.PeriodEnd,
                CardStatusTypeId = cardStatus.CardStatusTypeId
            };
        }

        /// <summary>
        /// Маппинг инвалидности работника
        /// </summary>
        /// <param name="dto">DTO создания "Инвалидность"</param>
        /// <returns>Инвалидность работника</returns>
        public static EmployeeDisability MapEmployeeDisability(this CreateEmployeeDisabilityDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new EmployeeDisability
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Type = dto.Type
            };
        }

        /// <summary>
        /// Маппинг инвалидности работника
        /// </summary>
        /// <param name="dto">DTO обновления "Инвалидность"</param>
        /// <returns>Инвалидность работника</returns>
        public static EmployeeDisability MapEmployeeDisability(this UpdateEmployeeDisabilityDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new EmployeeDisability
            {
                Id = dto.Id,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Type = dto.Type
            };
        }

        /// <summary>
        /// Маппинг инвалидности работника
        /// </summary>
        /// <param name="disability">Инвалидность работника</param>
        /// <returns>DTO "Инвалидность"</returns>
        public static EmployeeDisabilityDto MapEmployeeDisability(this EmployeeDisability disability)
        {
            if (disability == null) throw new NullReferenceException(nameof(disability));

            return new EmployeeDisabilityDto
            {
                Id = disability.Id,
                PeriodBegin = disability.PeriodBegin,
                PeriodEnd = disability.PeriodEnd,
                Type = disability.Type
            };
        }

        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="dto">DTO создания "Спецстаж"</param>
        /// <returns>Спецстаж</returns>
        public static EmployeeSpecialSeniority MapEmployeeSpecialSeniority(this CreateEmployeeSpecialSeniorityDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new EmployeeSpecialSeniority
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                SpecialSeniorityId = dto.SpecialSeniorityId
            };
        }

        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="dto">DTO обновления "Спецстаж"</param>
        /// <returns>Спецстаж</returns>
        public static EmployeeSpecialSeniority MapEmployeeSpecialSeniority(this UpdateEmployeeSpecialSeniorityDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new EmployeeSpecialSeniority
            {
                Id = dto.Id,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                SpecialSeniorityId = dto.SpecialSeniorityId
            };
        }

        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="specialSeniority">Спецстаж</param>
        /// <returns>DTO "Спецстаж"</returns>
        public static EmployeeSpecialSeniorityDto MapEmployeeSpecialSeniority(this EmployeeSpecialSeniority specialSeniority)
        {
            if (specialSeniority == null) throw new NullReferenceException(nameof(specialSeniority));

            return new EmployeeSpecialSeniorityDto
            {
                Id = specialSeniority.Id,
                PeriodBegin = specialSeniority.PeriodBegin,
                PeriodEnd = specialSeniority.PeriodEnd,
                SpecialSeniorityId = specialSeniority.SpecialSeniorityId
            };
        }

        /// <summary>
        /// Маппинг карточки работника
        /// </summary>
        /// <param name="employeeCard">Карточка работника</param>
        /// <returns>DTO "Карточка работника"</returns>
        public static EmployeeCardDto MapEmployeeCardDto(this EmployeeCard employeeCard)
        {
            if (employeeCard == null) throw new NullReferenceException(nameof(employeeCard));

            List<EmployeeChildrenDto> employeeChildren = null;
            List<EmployeeTaxReliefDto> employeeTaxReliefs = null;
            List<EmployeeCardStatusDto> employeeCardStatuses = null;
            List<EmployeeDisabilityDto> employeeDisabilities = null;
            List<EmployeeSpecialSeniorityDto> employeeSpecialSeniorities = null;

            if (employeeCard.EmployeeChildren != null)
            {
                employeeChildren = new List<EmployeeChildrenDto>();

                foreach (var children in employeeCard.EmployeeChildren)
                    employeeChildren.Add(children.MapEmployeeChildren());
            }

            if (employeeCard.EmployeeTaxReliefs != null)
            {
                employeeTaxReliefs = new List<EmployeeTaxReliefDto>();

                foreach (var taxRelief in employeeCard.EmployeeTaxReliefs)
                    employeeTaxReliefs.Add(taxRelief.MapEmployeeTaxRelief());
            }

            if (employeeCard.EmployeeCardStatuses != null)
            {
                employeeCardStatuses = new List<EmployeeCardStatusDto>();

                foreach (var cardStatus in employeeCard.EmployeeCardStatuses)
                    employeeCardStatuses.Add(cardStatus.MapEmployeeCardStatus());
            }

            if (employeeCard.EmployeeDisabilities != null)
            {
                employeeDisabilities = new List<EmployeeDisabilityDto>();

                foreach (var disability in employeeCard.EmployeeDisabilities)
                    employeeDisabilities.Add(disability.MapEmployeeDisability());
            }

            if (employeeCard.EmployeeSpecialSeniorities != null)
            {
                employeeSpecialSeniorities = new List<EmployeeSpecialSeniorityDto>();

                foreach (var specialSeniority in employeeCard.EmployeeSpecialSeniorities)
                    employeeSpecialSeniorities.Add(specialSeniority.MapEmployeeSpecialSeniority());
            }


            return new EmployeeCardDto
            {
                Id = employeeCard.Id,
                FirstName = employeeCard.FirstName,
                MiddleName = employeeCard.MiddleName,
                LastName = employeeCard.LastName,
                TaxIdentificationNumber = employeeCard.TaxIdentificationNumber,
                Seniority = employeeCard.Seniority,
                Grade = employeeCard.Grade,
                BirthDate = employeeCard.BirthDate,
                EntryDate = employeeCard.EntryDate,
                DismissalDate = employeeCard.DismissalDate,
                PensionDate = employeeCard.PensionDate,
                Sex = employeeCard.Sex,
                EmployeeChildren = employeeChildren,
                EmployeeTaxReliefs = employeeTaxReliefs,
                EmployeeCardStatuses = employeeCardStatuses,
                EmployeeDisabilities = employeeDisabilities,
                EmployeeSpecialSeniorities = employeeSpecialSeniorities
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Карточки работника"
        /// </summary>
        /// <param name="employeeCards">Запрос последовательности "Карточки работника"</param>
        /// <returns>Запрос последовательности DTO "Карточки работника"</returns>
        public static IQueryable<EmployeeCardDto> SelectEmployeeCardDtos(this IQueryable<EmployeeCard> employeeCards)
        {
            return employeeCards.Select(employeeCard => new EmployeeCardDto
            {
                Id = employeeCard.Id,
                FirstName = employeeCard.FirstName,
                MiddleName = employeeCard.MiddleName,
                LastName = employeeCard.LastName,
                TaxIdentificationNumber = employeeCard.TaxIdentificationNumber,
                Seniority = employeeCard.Seniority,
                Grade = employeeCard.Grade,
                BirthDate = employeeCard.BirthDate,
                EntryDate = employeeCard.EntryDate,
                DismissalDate = employeeCard.DismissalDate,
                PensionDate = employeeCard.PensionDate,
                Sex = employeeCard.Sex
            });
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Карточки работника"
        /// </summary>
        /// <param name="employeeCards">Запрос последовательности "Карточки работника"</param>
        /// <param name="id">Идентификатор карточки</param>
        /// <returns>Запрос последовательности DTO "Карточки работника"</returns>
        public static IQueryable<EmployeeCardDto> SelectEmployeeCardDtos(this IQueryable<EmployeeCard> employeeCards, int id)
        {
            return employeeCards.Where(rec => rec.Id == id).Select(employeeCard => new EmployeeCardDto
            {
                Id = employeeCard.Id,
                FirstName = employeeCard.FirstName,
                MiddleName = employeeCard.MiddleName,
                LastName = employeeCard.LastName,
                TaxIdentificationNumber = employeeCard.TaxIdentificationNumber,
                Seniority = employeeCard.Seniority,
                Grade = employeeCard.Grade,
                BirthDate = employeeCard.BirthDate,
                EntryDate = employeeCard.EntryDate,
                DismissalDate = employeeCard.DismissalDate,
                PensionDate = employeeCard.PensionDate,
                Sex = employeeCard.Sex,
                EmployeeChildren = employeeCard.EmployeeChildren.Select(children => new EmployeeChildrenDto
                {
                    Id = children.Id,
                    Number = children.Number,
                    PeriodBegin = children.PeriodBegin,
                    PeriodEnd = children.PeriodEnd
                }).ToList(),
                EmployeeCardStatuses = employeeCard.EmployeeCardStatuses.Select(cardStatus => new EmployeeCardStatusDto
                {
                    Id = cardStatus.Id,
                    PeriodBegin = cardStatus.PeriodBegin,
                    PeriodEnd = cardStatus.PeriodEnd,
                    CardStatusTypeId = cardStatus.CardStatusTypeId,
                    CardStatusTypeName = cardStatus.CardStatusType.Name
                }).ToList(),
                EmployeeDisabilities = employeeCard.EmployeeDisabilities.Select(disability => new EmployeeDisabilityDto
                {
                    Id = disability.Id,
                    PeriodBegin = disability.PeriodBegin,
                    PeriodEnd = disability.PeriodEnd,
                    Type = disability.Type
                }).ToList(),
                EmployeeSpecialSeniorities = employeeCard.EmployeeSpecialSeniorities.Select(specialSeniority => new EmployeeSpecialSeniorityDto
                {
                    Id = specialSeniority.Id,
                    PeriodBegin = specialSeniority.PeriodBegin,
                    PeriodEnd = specialSeniority.PeriodEnd,
                    SpecialSeniorityId = specialSeniority.SpecialSeniorityId,
                    SpecialSeniorityName = specialSeniority.SpecialSeniority.Name
                }).ToList(),
                EmployeeTaxReliefs = employeeCard.EmployeeTaxReliefs.Select(taxRelief => new EmployeeTaxReliefDto
                {
                    Id = taxRelief.Id,
                    PeriodBegin = taxRelief.PeriodBegin,
                    PeriodEnd = taxRelief.PeriodEnd,
                    Сoefficient = taxRelief.Сoefficient
                }).ToList()
            });
        }
    }
}
