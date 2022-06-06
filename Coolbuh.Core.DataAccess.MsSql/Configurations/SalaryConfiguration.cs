using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация зарплаты
    /// </summary>
    public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable("Salaries");
            builder.HasKey(rec => rec.Id);

            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.Salaries)
                .HasForeignKey(rec => rec.EmployeeCardId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(rec => rec.Department)
                .WithMany(rec => rec.Salaries)
                .HasForeignKey(rec => rec.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(rec => rec.OtherAllowance)
                .WithMany(rec => rec.Salaries)
                .HasForeignKey(rec => rec.OtherAllowanceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(rec => rec.PensionAllowance)
                .WithMany(rec => rec.Salaries)
                .HasForeignKey(rec => rec.PensionAllowanceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(rec => rec.GradeAllowance)
                .WithMany(rec => rec.Salaries)
                .HasForeignKey(rec => rec.GradeAllowanceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(rec => new { rec.AccountingPeriod, rec.DepartmentId },
                "IX_Salaries_AccountingPeriod_DepartmentId");
            builder.HasIndex(rec => rec.AccountingPeriod, "IX_Salaries_AccountingPeriod");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.EmployeeCardId)
                .HasColumnName("employeeCardId");

            builder.Property(e => e.DepartmentId)
                .HasColumnName("departmentId");

            builder.Property(e => e.AccountingPeriod)
                .HasColumnName("accountingPeriod")
                .HasColumnType("date");

            builder.Property(e => e.Days)
                .HasColumnName("days");

            builder.Property(e => e.Hours)
                .HasColumnName("hours")
                .HasColumnType("numeric(5,2)");

            builder.Property(e => e.BaseSum)
                .HasColumnName("baseSum")
                .HasColumnType("numeric(10,2)");

            builder.Property(e => e.PensionAllowanceId)
                .HasColumnName("pensionAllowanceId");

            builder.Property(e => e.PensionAllowanceSum)
                .HasColumnName("pensionAllowanceSum")
                .HasColumnType("numeric(10,2)");

            builder.Property(e => e.GradeAllowanceId)
                .HasColumnName("gradeAllowanceId");

            builder.Property(e => e.GradeAllowanceSum)
                .HasColumnName("gradeAllowanceSum")
                .HasColumnType("numeric(10,2)");

            builder.Property(e => e.OtherAllowanceId)
                .HasColumnName("otherAllowanceId");

            builder.Property(e => e.OtherAllowanceSum)
                .HasColumnName("otherAllowanceSum")
                .HasColumnType("numeric(10,2)");

            builder.Property(e => e.TotalSum)
                .HasColumnName("totalSum")
                .HasColumnType("numeric(10,2)");
        }
    }
}
