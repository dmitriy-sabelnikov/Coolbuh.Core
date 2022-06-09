using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace Coolbuh.Core.UseCases.Tests.Unit.Handlers
{
    public static class FakeDbRepository
    {
        public static Mock<IDbContext> GetFakeDbContext()
        {
            return new Mock<IDbContext>();
        }

        public static Mock<DbSet<AdditionalAccrual>> GetFakeAdditionalAccruals()
        {
            var employeeCard = GetFakeEmployeeCards().Object.First();
            var department = GetFakeListDepartments().Object.First();
            var additionalAccrualType = GetFakeListAdditionalAccrualTypes().Object.First();

            var additionalAccruals = new List<AdditionalAccrual>()
            {
                new AdditionalAccrual
                {
                    Id = 1,
                    EmployeeCardId = employeeCard.Id,
                    DepartmentId = department.Id,
                    AccountingPeriod = new DateTime(2022, 05, 01),
                    AdditionalAccrualTypeId = additionalAccrualType.Id,
                    Sum = 10,
                    EmployeeCard = employeeCard,
                    Department = department,
                    AdditionalAccrualType = additionalAccrualType                    
                },
                new AdditionalAccrual
                {
                    Id = 2,
                    EmployeeCardId = employeeCard.Id,
                    DepartmentId = department.Id,
                    AccountingPeriod = new DateTime(2022, 04, 01),
                    AdditionalAccrualTypeId = additionalAccrualType.Id,
                    Sum = 10,
                    EmployeeCard = employeeCard,
                    Department = department,
                    AdditionalAccrualType = additionalAccrualType
                }
            };

            return additionalAccruals.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<AdditionalPayment>> GetFakeAdditionalPayments()
        {
            var employeeCard = GetFakeEmployeeCards().Object.First();
            var additionalPaymentType = GetFakeListAdditionalPaymentTypes().Object.First();

            var additionalPayments = new List<AdditionalPayment>()
            {
                new AdditionalPayment
                {
                    Id = 1,
                    EmployeeCardId = employeeCard.Id,
                    AccountingPeriod = new DateTime(2022, 05, 01),
                    AdditionalPaymentTypeId = additionalPaymentType.Id,
                    Sum = 10,
                    EmployeeCard = employeeCard,
                    AdditionalPaymentType = additionalPaymentType
                },
                new AdditionalPayment
                {
                    Id = 1,
                    EmployeeCardId = employeeCard.Id,
                    AccountingPeriod = new DateTime(2022, 04, 01),
                    AdditionalPaymentTypeId = additionalPaymentType.Id,
                    Sum = 10,
                    EmployeeCard = employeeCard,
                    AdditionalPaymentType = additionalPaymentType
                }
            };

            return additionalPayments.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ApplicationSetting>> GetFakeApplicationSettings()
        {
            var applicationSettings = new List<ApplicationSetting>
            {
                new ApplicationSetting
                {
                    Type = ApplicationSettingType.AccountingYear,
                    DigitValue = 1
                },
                new ApplicationSetting
                {
                    Type = ApplicationSettingType.CompanyName,
                    StringValue = "Ivanov"
                },
                new ApplicationSetting
                {
                    Type = ApplicationSettingType.CompanyUSREOU,
                    StringValue = "000000"
                }
            };

            return applicationSettings.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<CivilLawContract>> GetFakeCivilLawContracts()
        {
            var employeeCard = GetFakeEmployeeCards().Object.First();
            var department = GetFakeListDepartments().Object.First();

            var civilLawContracts = new List<CivilLawContract>
            {
                new CivilLawContract
                {
                    Id = 1,
                    EmployeeCardId = employeeCard.Id,
                    DepartmentId = department.Id,
                    AccountingPeriod = new DateTime(2022, 05, 01),
                    AccrualPeriod = new DateTime(2022, 05, 01),
                    Days = 1,
                    Sum = 1,
                    EmployeeCard = employeeCard,
                    Department = department
                },
                new CivilLawContract
                {
                    Id = 2,
                    EmployeeCardId = employeeCard.Id,
                    DepartmentId = department.Id,
                    AccountingPeriod = new DateTime(2022, 06, 01),
                    AccrualPeriod = new DateTime(2022, 06, 01),
                    Days = 2,
                    Sum = 2,
                    EmployeeCard = employeeCard,
                    Department = department
                },

            };

            return civilLawContracts.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ConsolidateReportCatalog>> GetFakeConsolidateReportCatalogs()
        {
            var consolidateReportCatalogs = new List<ConsolidateReportCatalog>
            {
                new ConsolidateReportCatalog
                {
                    Id = 1,
                    Name = "Test",
                    Number = 1,
                    Year = 2022,
                    Quarter = 1,
                    CalculateDate = new DateTime(2022, 05, 01),
                    Flags = 0
                },
                new ConsolidateReportCatalog
                {
                    Id = 2,
                    Name = "Test",
                    Number = 2,
                    Year = 2022,
                    Quarter = 2,
                    CalculateDate = new DateTime(2022, 05, 01),
                    Flags = 0
                }
            };

            return consolidateReportCatalogs.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<EmployeeCard>> GetFakeEmployeeCards()
        {
            var employeeCards = new List<EmployeeCard>
            {
                new EmployeeCard
                {
                    Id = 1,
                    FirstName = "МИКОЛА",
                    MiddleName = "МИХАЙЛОВИЧ",
                    LastName = "БОРКIВЕЦЬ",
                    TaxIdentificationNumber = "2155080414",
                    Seniority = 23,
                    Grade = 2,
                    BirthDate = null,
                    EntryDate = null,
                    DismissalDate = null,
                    PensionDate = new DateTime(2019, 01, 01),
                    Sex = EmployeeCardSex.Male,
                    EmployeeCardStatuses = new List<EmployeeCardStatus>(),
                    EmployeeChildren = new List<EmployeeChildren>(),
                    EmployeeDisabilities = new List<EmployeeDisability>(),
                    EmployeeSpecialSeniorities = new List<EmployeeSpecialSeniority>(),
                    EmployeeTaxReliefs = new List<EmployeeTaxRelief>()
                },
                new EmployeeCard
                {
                    Id = 2,
                    FirstName = "КАТЕРИНА",
                    MiddleName = "IВАНIВНА",
                    LastName = "БОГДАН",
                    TaxIdentificationNumber = "2702510888",
                    Seniority = 9,
                    Grade = 0,
                    BirthDate = null,
                    EntryDate = null,
                    DismissalDate = null,
                    PensionDate = null,
                    Sex = EmployeeCardSex.Female,
                    EmployeeCardStatuses = new List<EmployeeCardStatus>(),
                    EmployeeChildren = new List<EmployeeChildren>(),
                    EmployeeDisabilities = new List<EmployeeDisability>(),
                    EmployeeSpecialSeniorities = new List<EmployeeSpecialSeniority>(),
                    EmployeeTaxReliefs = new List<EmployeeTaxRelief>()
                }
            };

            return employeeCards.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListAdditionalAccrualType>> GetFakeListAdditionalAccrualTypes()
        {
            var additionalAccrualTypes = new List<ListAdditionalAccrualType>()
            {
                new ListAdditionalAccrualType
                {
                    Id = 1,
                    Code = "1",
                    Name = "премiя",
                    Flags = (int)ListAdditionalAccrualTypeFlags.Calculate
                },
                new ListAdditionalAccrualType
                {
                    Id = 2,
                    Code = "2",
                    Name = "алiменти",
                    Flags = (int)ListAdditionalAccrualTypeFlags.Calculate
                }
            };

            return additionalAccrualTypes.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListAdditionalPaymentType>> GetFakeListAdditionalPaymentTypes()
        {
            var additionalPaymentTypes = new List<ListAdditionalPaymentType>()
            {
                new ListAdditionalPaymentType
                {
                    Id = 1,
                    Code = "1",
                    Name = "харчування"
                },
                new ListAdditionalPaymentType
                {
                    Id = 2,
                    Code = "2",
                    Name = "позика"
                }
            };

            return additionalPaymentTypes.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListAdministration>> GetFakeListAdministrations()
        {
            var position = GetFakeListPositions().Object.First();
            var cardStatusTypes = new List<ListAdministration>
            {
                new ListAdministration
                {
                    Id = 1,
                    TaxIdentificationNumber = "2329213132",
                    FullName = "Гнилосир I.Ф.",
                    TelephoneNumber = "21273",
                    PositionId = position.Id,
                    Position = position
                }
            };

            return cardStatusTypes.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListCardStatusType>> GetFakeListCardStatusTypes()
        {
            var cardStatusTypes = new List<ListCardStatusType>
            {
                new ListCardStatusType
                {
                    Id = 1,
                    Code = "1",
                    Name = "Постійний"
                },
                new ListCardStatusType
                {
                    Id = 2,
                    Code = "2",
                    Name = "Тимчасовий"
                }
            };

            return cardStatusTypes.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListDepartment>> GetFakeListDepartments()
        {
            var departments = new List<ListDepartment>
            {
                new ListDepartment
                {
                    Id = 1,
                    Code = "1",
                    Name = "Автопарк"
                },
                new ListDepartment
                {
                    Id = 2,
                    Code = "2",
                    Name = "Автопарк ремонти"
                }
            };

            return departments.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListGradeAllowance>> GetFakeListGradeAllowances()
        {
            var department = GetFakeListDepartments().Object.First();

            var gradeAllowances = new List<ListGradeAllowance>
            {
                new ListGradeAllowance
                {
                    Id = 1,
                    Code = "1",
                    Name = "25% доплата шоферам",
                    Percent = 25,
                    Grade = 1,
                    DepartmentId = department.Id,
                    Flags = 0,
                    Department = department
                },
                new ListGradeAllowance
                {
                    Id = 1,
                    Code = "2",
                    Name = "20% доплата трактористам",
                    Percent = 20,
                    Grade = 1,
                    DepartmentId = department.Id,
                    Flags = 0,
                    Department = department
                }

            };

            return gradeAllowances.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListLivingWage>> GetFakeListLivingWages()
        {
            var livingWages = new List<ListLivingWage>
            {
                new ListLivingWage
                {
                    Id = 1,
                    PeriodBegin = new DateTime(2021, 07, 01),
                    PeriodEnd = new DateTime(2021, 11, 30),
                    Sum = 2379
                },
                new ListLivingWage
                {
                    Id = 2,
                    PeriodBegin = new DateTime(2021, 12, 01),
                    PeriodEnd = new DateTime(2021, 12, 31),
                    Sum = 2481
                }
            };

            return livingWages.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListMinimumSalary>> GetFakeListMinimumSalaries()
        {
            var minimumSalaries = new List<ListMinimumSalary>
            {
                new ListMinimumSalary
                {
                    Id = 1,
                    PeriodBegin = new DateTime(2020, 01, 01),
                    PeriodEnd = new DateTime(2021, 11, 30),
                    Sum = 6000
                },
                new ListMinimumSalary
                {
                    Id = 2,
                    PeriodBegin = new DateTime(2021, 12, 01),
                    PeriodEnd = new DateTime(2021, 12, 31),
                    Sum = 6500
                }
            };

            return minimumSalaries.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListOtherAllowance>> GetFakeListOtherAllowances()
        {
            var otherAllowances = new List<ListOtherAllowance>
            {
                new ListOtherAllowance
                {
                    Id = 1,
                    Code = "1",
                    Name = "премія",
                    Percent = 10,
                    Flags = 0
                },
                new ListOtherAllowance
                {
                    Id = 2,
                    Code = "2",
                    Name = "доплати",
                    Percent = 30,
                    Flags = 0
                }
            };

            return otherAllowances.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListPensionAllowance>> GetFakeListPensionAllowances()
        {
            var pensionAllowances = new List<ListPensionAllowance>
            {
                new ListPensionAllowance
                {
                    Id = 1,
                    Code = "1",
                    Name = "10% доплата пенсіонеру",
                    Percent = 10,
                    Flags = 0
                },
                new ListPensionAllowance
                {
                    Id = 2,
                    Code = "2",
                    Name = "пенсіонеру",
                    Percent = 20,
                    Flags = 0
                }
            };

            return pensionAllowances.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListPosition>> GetFakeListPositions()
        {
            var positions = new List<ListPosition>
            {
                new ListPosition
                {
                    Id = 1,
                    Code = "1",
                    Name = "Голова"
                }
            };

            return positions.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListSocialBenefit>> GetFakeListSocialBenefits()
        {
            var socialBenefits = new List<ListSocialBenefit>
            {
                new ListSocialBenefit
                {
                    Id = 1,
                    PeriodBegin = new DateTime(2022, 01, 01),
                    PeriodEnd = new DateTime(2022, 02, 28),
                    Sum = 1135,
                    LimitSum = 3500
                },
                new ListSocialBenefit
                {
                    Id = 2,
                    PeriodBegin = new DateTime(2022, 03, 01),
                    Sum = 2135,
                    LimitSum = 5500
                }
            };

            return socialBenefits.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<ListSpecialSeniority>> GetFakeListSpecialSeniorities()
        {
            var specialSeniorities = new List<ListSpecialSeniority>
            {
                new ListSpecialSeniority
                {
                    Id = 1,
                    Code = "1",
                    Name = "тракторист",
                    ReasonCode = "3П3013В1"
                },
                new ListSpecialSeniority
                {
                    Id = 1,
                    Code = "1",
                    Name = "доярка",
                    ReasonCode = "3П3013Д1"
                }
            };

            return specialSeniorities.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<Payment>> GetFakePayments()
        {
            var employeeCard = GetFakeEmployeeCards().Object.First();

            var payments = new List<Payment>
            {
                new Payment
                {
                    Id = 1,
                    EmployeeCardId = employeeCard.Id,
                    AccountingPeriod = new DateTime(2022, 05, 01),
                    Sum = 10,
                    EmployeeCard = employeeCard
                },
                new Payment
                {
                    Id = 2,
                    EmployeeCardId = employeeCard.Id,
                    AccountingPeriod = new DateTime(2022, 06, 01),
                    Sum = 20,
                    EmployeeCard = employeeCard
                }
            };

            return payments.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<Salary>> GetFakeSalaries()
        {
            var employeeCard = GetFakeEmployeeCards().Object.First();
            var department = GetFakeListDepartments().Object.First();
            var pensionAllowance = GetFakeListPensionAllowances().Object.First();
            var gradeAllowance = GetFakeListGradeAllowances().Object.First();
            var otherAllowance = GetFakeListOtherAllowances().Object.First();

            var salaries = new List<Salary>
            {
                new Salary
                {
                    Id = 1,
                    EmployeeCardId = employeeCard.Id,
                    DepartmentId = department.Id,
                    AccountingPeriod = new DateTime(2022, 05, 01),
                    Days = 10,
                    Hours = 80,
                    BaseSum = 1000,
                    PensionAllowanceId = pensionAllowance.Id,
                    PensionAllowanceSum = 190,
                    GradeAllowanceId = gradeAllowance.Id,
                    GradeAllowanceSum = 100,
                    OtherAllowanceId = otherAllowance.Id,
                    OtherAllowanceSum = 210,
                    TotalSum = 1500,
                    EmployeeCard = employeeCard,
                    Department = department,
                    PensionAllowance = pensionAllowance,
                    GradeAllowance = gradeAllowance,
                    OtherAllowance = otherAllowance
                }
            };

            return salaries.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<SickList>> GetFakeSickLists()
        {
            var employeeCard = GetFakeEmployeeCards().Object.First();
            var department = GetFakeListDepartments().Object.First();

            var sickLists = new List<SickList>
            {
                new SickList
                {
                    Id = 1,
                    EmployeeCardId = employeeCard.Id,
                    DepartmentId = department.Id,
                    AccountingPeriod = new DateTime(2022, 05, 01),
                    AccrualPeriod = new DateTime(2022, 05, 01),
                    EnterpriseDays = 1,
                    EnterpriseSum = 1,
                    SocialInsuranceDays = 2,
                    SocialInsuranceSum = 2,
                    EmployeeCard = employeeCard,
                    Department = department
                },
                new SickList
                {
                    Id = 1,
                    EmployeeCardId = employeeCard.Id,
                    DepartmentId = department.Id,
                    AccountingPeriod = new DateTime(2022, 04, 01),
                    AccrualPeriod = new DateTime(2022, 04, 01),
                    EnterpriseDays = 1,
                    EnterpriseSum = 1,
                    SocialInsuranceDays = 2,
                    SocialInsuranceSum = 2,
                    EmployeeCard = employeeCard,
                    Department = department
                }
            };

            return sickLists.AsQueryable().BuildMockDbSet();
        }

        public static Mock<DbSet<Vocation>> GetFakeVocations()
        {
            var employeeCard = GetFakeEmployeeCards().Object.First();
            var department = GetFakeListDepartments().Object.First();

            var vocations = new List<Vocation>
            {
                new Vocation
                {
                    Id = 1,
                    EmployeeCardId = employeeCard.Id,
                    DepartmentId = department.Id,
                    AccountingPeriod = new DateTime(2022, 05, 01),
                    AccrualPeriod = new DateTime(2022, 05, 01),
                    Days = 1,
                    Sum = 1,
                    EmployeeCard = employeeCard,
                    Department = department
                },
                new Vocation
                {
                    Id = 2,
                    EmployeeCardId = employeeCard.Id,
                    DepartmentId = department.Id,
                    AccountingPeriod = new DateTime(2022, 06, 01),
                    AccrualPeriod = new DateTime(2022, 06, 01),
                    Days = 2,
                    Sum = 2,
                    EmployeeCard = employeeCard,
                    Department = department
                },

            };

            return vocations.AsQueryable().BuildMockDbSet();
        }
    }
}
