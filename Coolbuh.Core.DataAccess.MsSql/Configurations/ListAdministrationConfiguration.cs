using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Администрации"
    /// </summary>
    public class ListAdministrationConfiguration : IEntityTypeConfiguration<ListAdministration>
    {
        public void Configure(EntityTypeBuilder<ListAdministration> builder)
        {
            builder.ToTable("ListAdministrations");
            builder.HasKey(rec => rec.Id);
            builder.HasOne(rec => rec.Position)
                .WithMany(rec => rec.Administrations)
                .HasForeignKey(rec => rec.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.TaxIdentificationNumber)
                .HasColumnName("taxIdentificationNumber")
                .HasMaxLength(ListAdministrationConstants.TaxIdentificationNumberLength);

            builder.Property(e => e.FullName)
                .HasColumnName("fullName")
                .HasMaxLength(ListAdministrationConstants.FullNameLength);

            builder.Property(e => e.TelephoneNumber)
                .HasColumnName("telephoneNumber")
                .HasMaxLength(ListAdministrationConstants.TelephoneNumberLength);

            builder.Property(e => e.PositionId)
                .HasColumnName("positionId");
        }
    }
}