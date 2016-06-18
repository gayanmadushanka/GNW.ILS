using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GNW.ILS.Entities.Service.Models.Mapping
{
    public class EntityAddressMap : EntityTypeConfiguration<EntityAddress>
    {
        public EntityAddressMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EntityId, t.AddressId, t.AddressTypeId });

            // Properties
            this.Property(t => t.EntityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AddressId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AddressTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("EntityAddress");
            this.Property(t => t.EntityId).HasColumnName("EntityId");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.AddressTypeId).HasColumnName("AddressTypeId");
            this.Property(t => t.RowGuid).HasColumnName("RowGuid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Address)
                .WithMany(t => t.EntityAddresses)
                .HasForeignKey(d => d.AddressId);
            //this.HasRequired(t => t.AddressType)
            //    .WithMany(t => t.EntityAddresses)
            //    .HasForeignKey(d => d.AddressTypeId);
            this.HasRequired(t => t.Entity)
                .WithMany(t => t.EntityAddresses)
                .HasForeignKey(d => d.EntityId);

        }
    }
}
