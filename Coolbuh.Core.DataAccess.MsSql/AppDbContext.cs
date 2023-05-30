using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Coolbuh.Core.DataAccess.MsSql
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AdditionalAccrual> AdditionalAccruals { get; set; }
        public DbSet<AdditionalPayment> AdditionalPayments { get; set; }
        public DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        public DbSet<CivilLawContract> CivilLawContracts { get; set; }
        public DbSet<ConsolidateReportAppendix1> ConsolidateReportAppendixes1 { get; set; }
        public DbSet<ConsolidateReportAppendix4> ConsolidateReportAppendixes4 { get; set; }
        public DbSet<ConsolidateReportAppendix6> ConsolidateReportAppendixes6 { get; set; }
        public DbSet<ConsolidateReportCatalog> ConsolidateReportCatalogs { get; set; }
        public DbSet<EmployeeCard> EmployeeCards { get; set; }
        public DbSet<EmployeeCardStatus> EmployeeCardStatuses { get; set; }
        public DbSet<EmployeeChildren> EmployeeChildren { get; set; }
        public DbSet<EmployeeDisability> EmployeeDisabilities { get; set; }
        public DbSet<EmployeeSpecialSeniority> EmployeeSpecialSeniorities { get; set; }
        public DbSet<EmployeeTaxRelief> EmployeeTaxReliefs { get; set; }
        public DbSet<ListAdditionalAccrualType> ListAdditionalAccrualTypes { get; set; }
        public DbSet<ListAdditionalPaymentType> ListAdditionalPaymentTypes { get; set; }
        public DbSet<ListAdministration> ListAdministrations { get; set; }
        public DbSet<ListCardStatusType> ListCardStatusTypes { get; set; }
        public DbSet<ListDepartment> ListDepartments { get; set; }
        public DbSet<ListGradeAllowance> ListGradeAllowances { get; set; }
        public DbSet<ListLivingWage> ListLivingWages { get; set; }
        public DbSet<ListMinimumSalary> ListMinimumSalaries { get; set; }
        public DbSet<ListOtherAllowance> ListOtherAllowances { get; set; }
        public DbSet<ListPensionAllowance> ListPensionAllowances { get; set; }
        public DbSet<ListPosition> ListPositions { get; set; }
        public DbSet<ListSocialBenefit> ListSocialBenefits { get; set; }
        public DbSet<ListSpecialSeniority> ListSpecialSeniorities { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<SickList> SickLists { get; set; }
        public DbSet<Vocation> Vocations { get; set; }
        public ChangeTracker Tracker { get { return base.ChangeTracker; } }
        public void UpdateDb()
        {
            if (!Database.GetPendingMigrations().Any())
                return;

            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
