using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GNW.ILS.Entities.Service.Models.Mapping
{
    public class AddressTypeMap : EntityTypeConfiguration<AddressType>
    {
        public AddressTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.AddressTypeId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AddressType");
            this.Property(t => t.AddressTypeId).HasColumnName("AddressTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.RowGuid).HasColumnName("RowGuid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
