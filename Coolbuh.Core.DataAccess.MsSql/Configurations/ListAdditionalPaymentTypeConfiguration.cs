using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Типы дополнительных выплат"
    /// </summary>
    public class ListAdditionalPaymentTypeConfiguration : IEntityTypeConfiguration<ListAdditionalPaymentType>
    {
        public void Configure(EntityTypeBuilder<ListAdditionalPaymentType> builder)
        {
            builder.ToTable("ListAdditionalPaymentTypes");
            builder.HasKey(rec => rec.Id);
            builder.HasIndex(rec => rec.Code, "IX_ListAdditionalPaymentTypes_Code").IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(ListAdditionalPaymentTypeConstants.CodeLength);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(ListAdditionalPaymentTypeConstants.NameLength);
        }
    }
}
