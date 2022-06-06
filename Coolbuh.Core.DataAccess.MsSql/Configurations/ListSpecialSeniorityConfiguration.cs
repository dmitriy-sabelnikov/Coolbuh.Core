using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Спецстажи"
    /// </summary>
    public class ListSpecialSeniorityConfiguration : IEntityTypeConfiguration<ListSpecialSeniority>
    {
        public void Configure(EntityTypeBuilder<ListSpecialSeniority> builder)
        {
            builder.ToTable("ListSpecialSeniorities");
            builder.HasKey(rec => rec.Id);
            builder.HasIndex(rec => rec.Code, "IX_ListSpecialSeniorities_Code").IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(ListSpecialSeniorityConstants.CodeLength);

            builder.Property(e => e.ReasonCode)
                .HasColumnName("reasonCode")
                .HasMaxLength(ListSpecialSeniorityConstants.ReasonCodeLength);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(ListSpecialSeniorityConstants.NameLength);
        }
    }
}
