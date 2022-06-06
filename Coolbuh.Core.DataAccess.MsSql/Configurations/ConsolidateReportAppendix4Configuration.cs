using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация приложение 4
    /// </summary>
    public class ConsolidateReportAppendix4Configuration : IEntityTypeConfiguration<ConsolidateReportAppendix4>
    {
        public void Configure(EntityTypeBuilder<ConsolidateReportAppendix4> builder)
        {
            builder.ToTable("ConsolidateReportAppendix4s");
            builder.HasKey(rec => rec.Id);

            builder.HasOne(rec => rec.ConsolidateReportCatalog)
                .WithMany(rec => rec.ConsolidateReportAppendix4s)
                .HasForeignKey(rec => rec.ConsolidateReportCatalogId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.ConsolidateReportCatalogId)
                .HasColumnName("consolidateReportCatalogId");

            builder.Property(e => e.FirmUSREOU)
                .HasColumnName("firmUSREOU")
                .HasMaxLength(ApplicationSettingConstants.StringValueLength);

            builder.Property(e => e.FirmType)
                .HasColumnName("firmType");

            builder.Property(e => e.AccountingPeriod)
                .HasColumnName("accountingPeriod")
                .HasColumnType("date");

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

            builder.Property(e => e.EntryDate)
                .HasColumnName("entryDate")
                .HasColumnType("date");

            builder.Property(e => e.DismissalDate)
                .HasColumnName("dismissalDate")
                .HasColumnType("date");

            builder.Property(e => e.TaxReliefSign)
                .HasColumnName("taxReliefSign");

            builder.Property(e => e.AccrualIncomeSum)
                .HasColumnName("accrualIncomeSum")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.PaidIncomeSum)
                .HasColumnName("paidIncomeSum")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.AccrualTaxSum)
                .HasColumnName("accrualTaxSum")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.TransferTaxSum)
                .HasColumnName("transferTaxSum")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.IncomeSign)
                .HasColumnName("incomeSign");

            builder.Property(e => e.AccrualWarTaxSum)
                .HasColumnName("accrualWarTaxSum")
                .HasColumnType("numeric(16, 2)");

            builder.Property(e => e.TransferWarTaxSum)
                .HasColumnName("transferWarTaxSum")
                .HasColumnType("numeric(16, 2)");
        }
    }
}
