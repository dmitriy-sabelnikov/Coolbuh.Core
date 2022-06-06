using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Типы дополнительных начислений"
    /// </summary>
    public class ListAdditionalAccrualTypeConfiguration : IEntityTypeConfiguration<ListAdditionalAccrualType>
    {
        public void Configure(EntityTypeBuilder<ListAdditionalAccrualType> builder)
        {
            builder.ToTable("ListAdditionalAccrualTypes");
            builder.HasKey(rec => rec.Id);
            builder.HasIndex(rec => rec.Code, "IX_ListAdditionalAccrualTypes_Code").IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(ListAdditionalAccrualTypeConstants.CodeLength);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(ListAdditionalAccrualTypeConstants.NameLength);

            builder.Property(e => e.Flags)
                .HasColumnName("flags")
                .HasDefaultValue(0);
        }
    }
}
