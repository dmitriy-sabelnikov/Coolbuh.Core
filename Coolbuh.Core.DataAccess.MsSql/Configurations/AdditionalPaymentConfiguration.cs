using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация дополнительных выплат
    /// </summary>
    public class AdditionalPaymentConfiguration : IEntityTypeConfiguration<AdditionalPayment>
    {
        public void Configure(EntityTypeBuilder<AdditionalPayment> builder)
        {
            builder.ToTable("AdditionalPayments");
            builder.HasKey(rec => rec.Id);

            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.AdditionalPayments)
                .HasForeignKey(rec => rec.EmployeeCardId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(rec => rec.AdditionalPaymentType)
                .WithMany(rec => rec.AdditionalPayments)
                .HasForeignKey(rec => rec.AdditionalPaymentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasIndex(rec => new { rec.AccountingPeriod, rec.AdditionalPaymentTypeId },
                "IX_AdditionalPayments_AccountingPeriod_AdditionalPaymentTypeId");
            builder.HasIndex(rec => rec.AccountingPeriod, "IX_AdditionalPayments_AccountingPeriod");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.EmployeeCardId)
                .HasColumnName("employeeCardId");

            builder.Property(e => e.AdditionalPaymentTypeId)
                .HasColumnName("additionalPaymentTypeId");

            builder.Property(e => e.AccountingPeriod)
                .HasColumnName("accountingPeriod")
                .HasColumnType("date");

            builder.Property(e => e.Sum)
                .HasColumnName("sum")
                .HasColumnType("numeric(10, 2)");
        }
    }
}
