using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GNW.ILS.Entities.Service.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.AddressId);

            // Properties
            this.Property(t => t.AddressLine1)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.AddressLine2)
                .HasMaxLength(60);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.PostalCode)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Address");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.AddressLine1).HasColumnName("AddressLine1");
            this.Property(t => t.AddressLine2).HasColumnName("AddressLine2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.RowGuid).HasColumnName("RowGuid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
