using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация детей работника
    /// </summary>
    public class EmployeeChildrenConfiguration : IEntityTypeConfiguration<EmployeeChildren>
    {
        public void Configure(EntityTypeBuilder<EmployeeChildren> builder)
        {
            builder.ToTable("EmployeeChildren");
            builder.HasKey(rec => rec.Id);
            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.EmployeeChildren)
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

            builder.Property(e => e.Number)
                .HasColumnName("number");
        }
    }
}