using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Минимальные зарплаты"
    /// </summary>
    public class ListMinimumSalaryConfiguration : IEntityTypeConfiguration<ListMinimumSalary>
    {
        public void Configure(EntityTypeBuilder<ListMinimumSalary> builder)
        {
            builder.ToTable("ListMinimumSalaries");
            builder.HasKey(rec => rec.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.PeriodBegin)
                .HasColumnName("periodBegin")
                .HasColumnType("date");

            builder.Property(e => e.PeriodEnd)
                .HasColumnName("periodEnd")
                .HasColumnType("date");

            builder.Property(e => e.Sum)
                .HasColumnName("sum")
                .HasColumnType("numeric(16, 2)");
        }
    }
}