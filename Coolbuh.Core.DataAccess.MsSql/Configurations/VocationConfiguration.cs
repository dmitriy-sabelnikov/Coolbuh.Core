using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация отпусков
    /// </summary>
    public class VocationConfiguration : IEntityTypeConfiguration<Vocation>
    {
        public void Configure(EntityTypeBuilder<Vocation> builder)
        {
            builder.ToTable("Vocations");
            builder.HasKey(rec => rec.Id);

            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.Vocations)
                .HasForeignKey(rec => rec.EmployeeCardId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(rec => rec.Department)
                .WithMany(rec => rec.Vocations)
                .HasForeignKey(rec => rec.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(rec => new { rec.AccountingPeriod, rec.DepartmentId },
                "IX_Vocations_AccountingPeriod_DepartmentId");
            builder.HasIndex(rec => rec.AccountingPeriod, "IX_Vocations_AccountingPeriod");

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
