using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация больничных листов
    /// </summary>
    public class SickListConfiguration : IEntityTypeConfiguration<SickList>
    {
        public void Configure(EntityTypeBuilder<SickList> builder)
        {
            builder.ToTable("SickLists");
            builder.HasKey(rec => rec.Id);

            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.SickLists)
                .HasForeignKey(rec => rec.EmployeeCardId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(rec => rec.Department)
                .WithMany(rec => rec.SickLists)
                .HasForeignKey(rec => rec.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(rec => new { rec.AccountingPeriod, rec.DepartmentId },
                "IX_SickLists_AccountingPeriod_DepartmentId");
            builder.HasIndex(rec => rec.AccountingPeriod, "IX_SickLists_AccountingPeriod");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.EmployeeCardId)
                .HasColumnName("employeeCardId");

            builder.Property(e => e.DepartmentId)
                .HasColumnName("departmentId");

            builder.Property(e => e.AccountingPeriod)
                .HasColumnName("accountingPeriod")
                .HasColumnType("date");

            builder.Property(e => e.AccrualPeriod)
                .HasColumnName("accrualPeriod")
                .HasColumnType("date");

            builder.Property(e => e.EnterpriseDays)
                .HasColumnName("enterpriseDays");

            builder.Property(e => e.EnterpriseSum)
                .HasColumnName("enterpriseSum")
                .HasColumnType("numeric(10,2)");

            builder.Property(e => e.SocialInsuranceDays)
                .HasColumnName("socialInsuranceDays");

            builder.Property(e => e.SocialInsuranceSum)
                .HasColumnName("socialInsuranceSum")
                .HasColumnType("numeric(10,2)");
        }
    }
}
