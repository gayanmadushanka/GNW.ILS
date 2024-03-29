using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GNW.ILS.Entities.Service.Models.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            // Primary Key
            this.HasKey(t => t.EntityId);

            // Properties
            this.Property(t => t.EntityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Code)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.WebServiceUrl)
                .HasMaxLength(1024);

            // Table & Column Mappings
            this.ToTable("Company");
            this.Property(t => t.EntityId).HasColumnName("EntityId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.ActiveFlag).HasColumnName("ActiveFlag");
            this.Property(t => t.WebServiceUrl).HasColumnName("WebServiceUrl");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Entity)
                .WithOptional(t => t.Company);

        }
    }
}
