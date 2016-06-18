using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GNW.ILS.Entities.Service.Models.Mapping
{
    public class PhoneNumberTypeMap : EntityTypeConfiguration<PhoneNumberType>
    {
        public PhoneNumberTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.PhoneNumberTypeId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PhoneNumberType");
            this.Property(t => t.PhoneNumberTypeId).HasColumnName("PhoneNumberTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
