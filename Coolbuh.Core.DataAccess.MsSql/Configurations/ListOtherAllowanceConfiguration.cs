using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Другие надбавки"
    /// </summary>
    public class ListOtherAllowanceConfiguration : IEntityTypeConfiguration<ListOtherAllowance>
    {
        public void Configure(EntityTypeBuilder<ListOtherAllowance> builder)
        {
            builder.ToTable("ListOtherAllowances");
            builder.HasKey(rec => rec.Id);
            builder.HasIndex(rec => rec.Code, "IX_ListOtherAllowances_Code").IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(ListOtherAllowanceConstants.CodeLength);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(ListOtherAllowanceConstants.NameLength);

            builder.Property(e => e.Percent)
                .HasColumnName("percent")
                .HasColumnType("numeric(5, 2)");

            builder.Property(e => e.Flags)
                .HasColumnName("flags")
                .HasDefaultValue(0);
        }
    }
}
