using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация дополнительных начислений 
    /// </summary>
    public class AdditionalAccrualConfiguration : IEntityTypeConfiguration<AdditionalAccrual>
    {
        public void Configure(EntityTypeBuilder<AdditionalAccrual> builder)
        {
            builder.ToTable("AdditionalAccruals");
            builder.HasKey(rec => rec.Id);

            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.AdditionalAccruals)
                .HasForeignKey(rec => rec.EmployeeCardId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(rec => rec.Department)
                .WithMany(rec => rec.AdditionalAccruals)
                .HasForeignKey(rec => rec.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(rec => rec.AdditionalAccrualType)
                .WithMany(rec => rec.AdditionalAccruals)
                .HasForeignKey(rec => rec.AdditionalAccrualTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(rec => new { rec.AccountingPeriod, rec.DepartmentId },
                "IX_AdditionalAccruals_AccountingPeriod_DepartmentId");
            builder.HasIndex(rec => rec.AccountingPeriod, "IX_AdditionalAccruals_AccountingPeriod");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.EmployeeCardId)
                .HasColumnName("employeeCardId");

            builder.Property(e => e.DepartmentId)
                .HasColumnName("departmentId");

            builder.Property(e => e.AdditionalAccrualTypeId)
                .HasColumnName("additionalAccrualTypeId");

            builder.Property(e => e.AccountingPeriod)
                .HasColumnName("accountingPeriod")
                .HasColumnType("date");

            builder.Property(e => e.Sum)
                .HasColumnName("sum")
                .HasColumnType("numeric(10, 2)");
        }
    }
}
