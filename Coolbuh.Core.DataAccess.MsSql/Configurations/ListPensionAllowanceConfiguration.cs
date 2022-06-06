using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Надбавки за пенсию"
    /// </summary>
    public class ListPensionAllowanceConfiguration : IEntityTypeConfiguration<ListPensionAllowance>
    {
        public void Configure(EntityTypeBuilder<ListPensionAllowance> builder)
        {
            builder.ToTable("ListPensionAllowances");
            builder.HasKey(rec => rec.Id);
            builder.HasIndex(rec => rec.Code, "IX_ListPensionAllowances_Code").IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(ListPensionAllowanceConstants.CodeLength);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(ListPensionAllowanceConstants.NameLength);

            builder.Property(e => e.Percent)
                .HasColumnName("percent")
                .HasColumnType("numeric(5, 2)");

            builder.Property(e => e.Flags)
                .HasColumnName("flags")
                .HasDefaultValue(0);
        }
    }
}
