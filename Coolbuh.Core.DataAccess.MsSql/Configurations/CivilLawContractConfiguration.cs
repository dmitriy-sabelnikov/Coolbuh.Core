using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация договоров ГПХ
    /// </summary>
    public class CivilLawContractConfiguration : IEntityTypeConfiguration<CivilLawContract>
    {
        public void Configure(EntityTypeBuilder<CivilLawContract> builder)
        {
            builder.ToTable("CivilLawContracts");
            builder.HasKey(rec => rec.Id);

            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.CivilLawContracts)
                .HasForeignKey(rec => rec.EmployeeCardId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(rec => rec.Department)
                .WithMany(rec => rec.CivilLawContracts)
                .HasForeignKey(rec => rec.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(rec => new { rec.AccountingPeriod, rec.DepartmentId },
                "IX_CivilLawContracts_AccountingPeriod_DepartmentId");
            builder.HasIndex(rec => rec.AccountingPeriod, "IX_CivilLawContracts_AccountingPeriod");

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

            builder.Property(e => e.Days)
                .HasColumnName("days");

            builder.Property(e => e.Sum)
                .HasColumnName("sum")
                .HasColumnType("numeric(10, 2)");
        }
    }
}
