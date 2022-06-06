using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация каталога объединенной ведомости
    /// </summary>
    public class ConsolidateReportCatalogConfiguration : IEntityTypeConfiguration<ConsolidateReportCatalog>
    {
        public void Configure(EntityTypeBuilder<ConsolidateReportCatalog> builder)
        {
            builder.ToTable("ConsolidateReportCatalogs");
            builder.HasKey(rec => rec.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Quarter)
                .HasColumnName("quarter");

            builder.Property(e => e.Year)
                .HasColumnName("year");

            builder.Property(e => e.Number)
                .HasColumnName("number");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(ConsolidateReportCatalogConstants.NameLength);

            builder.Property(e => e.CalculateDate)
                .HasColumnName("calculateDate")
                .HasColumnType("datetime");

            builder.Property(e => e.Flags)
                .HasColumnName("flags");
        }
    }
}