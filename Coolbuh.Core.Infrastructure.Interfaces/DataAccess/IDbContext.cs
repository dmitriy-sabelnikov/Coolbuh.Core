using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.Infrastructure.Interfaces.DataAccess
{
    public interface IDbContext
    {
        DbSet<AdditionalAccrual> AdditionalAccruals { get; set; }
        DbSet<AdditionalPayment> AdditionalPayments { get; set; }
        DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        DbSet<CivilLawContract> CivilLawContracts { get; set; }
        DbSet<ConsolidateReportAppendix1> ConsolidateReportAppendixes1 { get; set; }
        DbSet<ConsolidateReportAppendix4> ConsolidateReportAppendixes4 { get; set; }
        DbSet<ConsolidateReportAppendix6> ConsolidateReportAppendixes6 { get; set; }
        DbSet<ConsolidateReportCatalog> ConsolidateReportCatalogs { get; set; }
        DbSet<EmployeeCard> EmployeeCards { get; set; }
        DbSet<EmployeeCardStatus> EmployeeCardStatuses { get; set; }
        DbSet<EmployeeChildren> EmployeeChildren { get; set; }
        DbSet<EmployeeDisability> EmployeeDisabilities { get; set; }
        DbSet<EmployeeSpecialSeniority> EmployeeSpecialSeniorities { get; set; }
        DbSet<EmployeeTaxRelief> EmployeeTaxReliefs { get; set; }
        DbSet<ListAdditionalAccrualType> ListAdditionalAccrualTypes { get; set; }
        DbSet<ListAdditionalPaymentType> ListAdditionalPaymentTypes { get; set; }
        DbSet<ListAdministration> ListAdministrations { get; set; }
        DbSet<ListCardStatusType> ListCardStatusTypes { get; set; }
        DbSet<ListDepartment> ListDepartments { get; set; }
        DbSet<ListGradeAllowance> ListGradeAllowances { get; set; }
        DbSet<ListLivingWage> ListLivingWages { get; set; }
        DbSet<ListMinimumSalary> ListMinimumSalaries { get; set; }
        DbSet<ListOtherAllowance> ListOtherAllowances { get; set; }
        DbSet<ListPensionAllowance> ListPensionAllowances { get; set; }
        DbSet<ListPosition> ListPositions { get; set; }
        DbSet<ListSocialBenefit> ListSocialBenefits { get; set; }
        DbSet<ListSpecialSeniority> ListSpecialSeniorities { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Salary> Salaries { get; set; }
        DbSet<SickList> SickLists { get; set; }
        DbSet<Vocation> Vocations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        ChangeTracker Tracker { get; }
        void UpdateDb();
    }
}
