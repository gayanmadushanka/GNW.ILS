using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GNW.ILS.Entities.Service.Models.Mapping
{
    public class EmailAddressMap : EntityTypeConfiguration<EmailAddress>
    {
        public EmailAddressMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EntityId, t.EmailAddressId });

            // Properties
            this.Property(t => t.EntityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EmailAddressId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.EmailAddress1)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EmailAddress");
            this.Property(t => t.EntityId).HasColumnName("EntityId");
            this.Property(t => t.EmailAddressId).HasColumnName("EmailAddressId");
            this.Property(t => t.EmailAddress1).HasColumnName("EmailAddress");
            this.Property(t => t.RowGuid).HasColumnName("RowGuid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Person)
                .WithMany(t => t.EmailAddresses)
                .HasForeignKey(d => d.EntityId);

        }
    }
}
