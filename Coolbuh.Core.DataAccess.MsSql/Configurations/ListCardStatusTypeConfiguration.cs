using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Типы статусов карточки"
    /// </summary>
    public class ListCardStatusTypeConfiguration : IEntityTypeConfiguration<ListCardStatusType>
    {
        public void Configure(EntityTypeBuilder<ListCardStatusType> builder)
        {
            builder.ToTable("ListCardStatusTypes");
            builder.HasKey(rec => rec.Id);
            builder.HasIndex(rec => rec.Code, "IX_ListCardStatusTypes_Code").IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(ListCardStatusTypeConstants.CodeLength);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(ListCardStatusTypeConstants.NameLength);
        }
    }
}