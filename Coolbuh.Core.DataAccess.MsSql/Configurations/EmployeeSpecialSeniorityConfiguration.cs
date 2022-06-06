using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация спецстажей работника
    /// </summary>
    public class EmployeeSpecialSeniorityConfiguration : IEntityTypeConfiguration<EmployeeSpecialSeniority>
    {
        public void Configure(EntityTypeBuilder<EmployeeSpecialSeniority> builder)
        {
            builder.ToTable("EmployeeSpecialSeniorities");
            builder.HasKey(rec => rec.Id);
            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.EmployeeSpecialSeniorities)
                .HasForeignKey(rec => rec.EmployeeCardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rec => rec.SpecialSeniority)
                .WithMany(rec => rec.EmployeeSpecialSeniorities)
                .HasForeignKey(rec => rec.SpecialSeniorityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

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

            builder.Property(e => e.SpecialSeniorityId)
                .HasColumnName("specialSeniorityId");
        }
    }
}