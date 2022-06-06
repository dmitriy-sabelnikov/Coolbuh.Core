using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coolbuh.Core.DataAccess.MsSql.Configurations
{
    /// <summary>
    /// Конфигурация справочника "Подразделения"
    /// </summary>
    public class ListDepartmentConfiguration : IEntityTypeConfiguration<ListDepartment>
    {
        public void Configure(EntityTypeBuilder<ListDepartment> builder)
        {
            builder.ToTable("ListDepartments");
            builder.HasKey(rec => rec.Id);
            builder.HasIndex(rec => rec.Code, "IX_ListDepartments_Code").IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(ListDepartmentConstants.CodeLength);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(ListDepartmentConstants.NameLength);
        }
    }
}
