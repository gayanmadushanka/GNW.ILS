using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GNW.ILS.Entities.Service.Models.Mapping
{
    public class CourtMap : EntityTypeConfiguration<Court>
    {
        public CourtMap()
        {
            // Primary Key
            this.HasKey(t => t.EntityId);

            // Properties
            this.Property(t => t.EntityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Court");
            this.Property(t => t.EntityId).HasColumnName("EntityId");
            this.Property(t => t.CourtTypeId).HasColumnName("CourtTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.RowGuid).HasColumnName("RowGuid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.CourtType)
                .WithMany(t => t.Courts)
                .HasForeignKey(d => d.CourtTypeId);
            this.HasRequired(t => t.Entity)
                .WithOptional(t => t.Court);

        }
    }
}
