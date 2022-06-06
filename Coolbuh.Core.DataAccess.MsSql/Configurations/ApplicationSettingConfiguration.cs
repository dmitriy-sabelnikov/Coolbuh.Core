using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация параметров приложения
    /// </summary>
    public class ApplicationSettingConfiguration : IEntityTypeConfiguration<ApplicationSetting>
    {
        public void Configure(EntityTypeBuilder<ApplicationSetting> builder)
        {
            builder.ToTable("ApplicationSettings");
            builder.HasKey(rec => rec.Type);

            builder.Property(e => e.Type)
                .HasColumnName("type");

            builder.Property(e => e.DigitValue)
                .HasColumnName("digitValue");

            builder.Property(e => e.StringValue)
                .HasColumnName("stringValue")
                .HasMaxLength(ApplicationSettingConstants.StringValueLength);
        }
    }
}
