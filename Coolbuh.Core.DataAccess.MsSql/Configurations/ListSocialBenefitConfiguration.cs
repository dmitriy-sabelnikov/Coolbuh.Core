using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Социальные льготы"
    /// </summary>
    public class ListSocialBenefitConfiguration : IEntityTypeConfiguration<ListSocialBenefit>
    {
        public void Configure(EntityTypeBuilder<ListSocialBenefit> builder)
        {
            builder.ToTable("ListSocialBenefits");
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

            builder.Property(e => e.LimitSum)
                .HasColumnName("limitSum")
                .HasColumnType("numeric(16, 2)");
        }
    }
}
