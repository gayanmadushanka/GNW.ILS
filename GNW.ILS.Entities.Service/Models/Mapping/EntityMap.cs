using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GNW.ILS.Entities.Service.Models.Mapping
{
    public class EntityMap : EntityTypeConfiguration<Entity>
    {
        public EntityMap()
        {
            // Primary Key
            this.HasKey(t => t.EntityId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Entity");
            this.Property(t => t.EntityId).HasColumnName("EntityId");
            this.Property(t => t.RowGuid).HasColumnName("RowGuid");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
