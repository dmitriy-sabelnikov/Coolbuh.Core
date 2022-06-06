using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация налоговых льгот работника
    /// </summary>
    public class EmployeeTaxReliefConfiguration : IEntityTypeConfiguration<EmployeeTaxRelief>
    {
        public void Configure(EntityTypeBuilder<EmployeeTaxRelief> builder)
        {
            builder.ToTable("EmployeeTaxReliefs");
            builder.HasKey(rec => rec.Id);
            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.EmployeeTaxReliefs)
                .HasForeignKey(rec => rec.EmployeeCardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.EmployeeCardId)
                .HasColumnName("employeeCardId");

            builder.Property(e => e.PeriodBegin)
                .HasColumnName("periodBegin")
                .HasColumnType("date");

            builder.Property(e => e.PeriodEnd)
                .HasColumnName("periodEnd")
                .HasColumnType("date");

            builder.Property(e => e.Сoefficient)
                .HasColumnName("coefficient")
                .HasColumnType("numeric(16, 2)");
        }
    }
}