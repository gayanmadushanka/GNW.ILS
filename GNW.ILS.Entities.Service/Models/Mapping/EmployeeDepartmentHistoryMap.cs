using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GNW.ILS.Entities.Service.Models.Mapping
{
    public class EmployeeDepartmentHistoryMap : EntityTypeConfiguration<EmployeeDepartmentHistory>
    {
        public EmployeeDepartmentHistoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EntityId, t.DepartmentId, t.StartDate });

            // Properties
            this.Property(t => t.EntityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DepartmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("EmployeeDepartmentHistory");
            this.Property(t => t.EntityId).HasColumnName("EntityId");
            this.Property(t => t.DepartmentId).HasColumnName("DepartmentId");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Department)
                .WithMany(t => t.EmployeeDepartmentHistories)
                .HasForeignKey(d => d.DepartmentId);
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.EmployeeDepartmentHistories)
                .HasForeignKey(d => d.EntityId);

        }
    }
}
