using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация статусов карточки работника
    /// </summary>
    public class EmployeeCardStatusConfiguration : IEntityTypeConfiguration<EmployeeCardStatus>
    {
        public void Configure(EntityTypeBuilder<EmployeeCardStatus> builder)
        {
            builder.ToTable("EmployeeCardStatuses");
            builder.HasKey(rec => rec.Id);
            builder.HasOne(rec => rec.EmployeeCard)
                .WithMany(rec => rec.EmployeeCardStatuses)
                .HasForeignKey(rec => rec.EmployeeCardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rec => rec.CardStatusType)
                .WithMany(rec => rec.EmployeeCardStatuses)
                .HasForeignKey(rec => rec.CardStatusTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.EmployeeCardId)
                .HasColumnName("employeeCardId");

            builder.Property(e => e.PeriodBegin)
                .HasColumnName("periodBegin")
                .HasColumnType("date");

            builder.Property(e => e.PeriodEnd)
                .HasColumnName("periodEnd")
                .HasColumnType("date");

            builder.Property(e => e.CardStatusTypeId)
                .HasColumnName("cardStatusTypeId");
        }
    }
}