using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация приложение 1
    /// </summary>
    public class ConsolidateReportAppendix1Configuration : IEntityTypeConfiguration<ConsolidateReportAppendix1>
    {
        public void Configure(EntityTypeBuilder<ConsolidateReportAppendix1> builder)
        {
            builder.ToTable("ConsolidateReportAppendix1s");
            builder.HasKey(rec => rec.Id);

            builder.HasOne(rec => rec.ConsolidateReportCatalog)
                .WithMany(rec => rec.ConsolidateReportAppendix1s)
                .HasForeignKey(rec => rec.ConsolidateReportCatalogId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.ConsolidateReportCatalogId)
                .HasColumnName("consolidateReportCatalogId");

            builder.Property(e => e.AccountingPeriod)
                .HasColumnName("accountingPeriod")
                .HasColumnType("date");

            builder.Property(e => e.IsUkraineNationality)
                .HasColumnName("isUkraineNationality")
                .HasColumnType("bit");

            builder.Property(e => e.Sex)
                .HasColumnName("sex");

            builder.Property(e => e.TaxIdentificationNumber)
                .HasColumnName("taxIdentificationNumber")
                .HasMaxLength(EmployeeCardConstants.TaxIdentificationNumberLength);

            builder.Property(e => e.FirstName)
              .HasColumnName("firstName")
              .HasMaxLength(EmployeeCardConstants.FirstNameLength);

            builder.Property(e => e.MiddleName)
                .HasColumnName("middleName")
                .HasMaxLength(EmployeeCardConstants.MiddleNameLength);

            builder.Property(e => e.LastName)
                .HasColumnName("lastName")
                .HasMaxLength(EmployeeCardConstants.LastNameLength);

            builder.Property(e => e.TaxIdentificationNumber)
                .HasColumnName("taxIdentificationNumber")
                .HasMaxLength(EmployeeCardConstants.TaxIdentificationNumberLength);

            builder.Property(e => e.CategoryCode)
                .HasColumnName("categoryCode");

            builder.Property(e => e.AccrualTypeCode)
                .HasColumnName("accrualTypeCode");

            builder.Property(e => e.AccrualMonth)
                .HasColumnName("accrualMonth");

            builder.Property(e => e.AccrualYear)
                .HasColumnName("accrualYear");

            builder.Property(e => e.TemporaryDisabilityDays)
                .HasColumnName("temporaryDisabilityDays");

            builder.Property(e => e.WithoutSalaryDays)
                .HasColumnName("withoutSalaryDays");

            builder.Property(e => e.EmploymentDays)
                .HasColumnName("employmentDays");

            builder.Property(e => e.MaternityLeaveDays)
                .HasColumnName("maternityLeaveDays");

            builder.Property(e => e.AccrualTotalSum)
                .HasColumnName("accrualTotalSum")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.MaxAccrualTotalSum)
                .HasColumnName("maxAccrualTotalSum")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.DifferenceSum)
                .HasColumnName("differenceSum")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.WithholdingUniformPaymentSum)
                .HasColumnName("withholdingUniformPaymentSum")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.AccrualUniformPaymentSum)
                .HasColumnName("accrualUniformPaymentSum")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.IsExistWorkBook)
                .HasColumnName("isExistWorkBook")
                .HasColumnType("bit");

            builder.Property(e => e.IsSpecialSeniority)
                .HasColumnName("isSpecialSeniority")
                .HasColumnType("bit");

            builder.Property(e => e.IsPartTimeWork)
                .HasColumnName("isPartTimeWork")
                .HasColumnType("bit");

            builder.Property(e => e.IsNewWorkplace)
                .HasColumnName("isNewWorkplace")
                .HasColumnType("bit");
        }
    }
}
