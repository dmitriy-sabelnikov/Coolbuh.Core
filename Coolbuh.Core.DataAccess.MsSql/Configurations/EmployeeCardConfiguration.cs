using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация карточки работников
    /// </summary>
    public class EmployeeCardConfiguration : IEntityTypeConfiguration<EmployeeCard>
    {
        public void Configure(EntityTypeBuilder<EmployeeCard> builder)
        {
            builder.ToTable("EmployeeCards");
            builder.HasKey(rec => rec.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.FirstName)
                .HasColumnName("firstName")
                .HasMaxLength(EmployeeCardConstants.FirstNameLength);

            builder.Property(e => e.MiddleName)
                .HasColumnName("middleName")
                .HasMaxLength(EmployeeCardConstants.MiddleNameLength);

            builder.Property(e => e.LastName)
                .HasColumnName("lastName")
                .HasMaxLength(EmployeeCardConstants.LastNameLength);

            builder.Property(e => e.TaxIdentificationNumber)
                .HasColumnName("taxIdentificationNumber")
                .HasMaxLength(EmployeeCardConstants.TaxIdentificationNumberLength);

            builder.Property(e => e.Seniority)
                .HasColumnName("seniority");

            builder.Property(e => e.Grade)
                .HasColumnName("grade");

            builder.Property(e => e.BirthDate)
                .HasColumnName("birthDate")
                .HasColumnType("date");

            builder.Property(e => e.EntryDate)
                .HasColumnName("entryDate")
                .HasColumnType("date");

            builder.Property(e => e.DismissalDate)
                .HasColumnName("dismissalDate")
                .HasColumnType("date");

            builder.Property(e => e.PensionDate)
                .HasColumnName("pensionDate")
                .HasColumnType("date");

            builder.Property(e => e.Sex)
                .HasColumnName("sex");
        }
    }
}