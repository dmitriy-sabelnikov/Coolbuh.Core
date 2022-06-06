using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Надбавки за классность"
    /// </summary>
    public class ListGradeAllowanceConfiguration : IEntityTypeConfiguration<ListGradeAllowance>
    {
        public void Configure(EntityTypeBuilder<ListGradeAllowance> builder)
        {
            builder.ToTable("ListGradeAllowances");
            builder.HasKey(rec => rec.Id);
            builder.HasIndex(rec => rec.Code, "IX_ListGradeAllowances_Code").IsUnique();
            builder.HasOne(rec => rec.Department)
                .WithMany(rec => rec.GradeAllowances)
                .HasForeignKey(rec => rec.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(ListGradeAllowanceConstants.CodeLength);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(ListGradeAllowanceConstants.NameLength);

            builder.Property(e => e.Percent)
                .HasColumnName("percent")
                .HasColumnType("numeric(5, 2)");

            builder.Property(e => e.Grade)
                .HasColumnName("grade");

            builder.Property(e => e.DepartmentId)
                .HasColumnName("departmentId")
                .HasColumnType("int");

            builder.Property(e => e.Flags)
                .HasColumnName("flags")
                .HasDefaultValue(0);
        }
    }
}
