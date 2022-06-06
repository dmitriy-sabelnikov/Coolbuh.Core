using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация инвалидностей работника
    /// </summary>
    public class EmployeeDisabilityConfiguration : IEntityTypeConfiguration<EmployeeDisability>
    {
        public void Configure(EntityTypeBuilder<EmployeeDisability> builder)
        {
            builder.ToTable("EmployeeDisabilities");
            builder.HasKey(rec => rec.Id);
            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.EmployeeDisabilities)
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

            builder.Property(e => e.Type)
                .HasColumnName("type");
        }
    }
}