using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GNW.ILS.Entities.Service.Models.Mapping
{
    public class PersonPhoneMap : EntityTypeConfiguration<PersonPhone>
    {
        public PersonPhoneMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EntityId, t.PhoneNumber, t.PhoneNumberTypeId });

            // Properties
            this.Property(t => t.EntityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.PhoneNumberTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("PersonPhone");
            this.Property(t => t.EntityId).HasColumnName("EntityId");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.PhoneNumberTypeId).HasColumnName("PhoneNumberTypeId");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Person)
                .WithMany(t => t.PersonPhones)
                .HasForeignKey(d => d.EntityId);
            this.HasRequired(t => t.PhoneNumberType)
                .WithMany(t => t.PersonPhones)
                .HasForeignKey(d => d.PhoneNumberTypeId);

        }
    }
}
