using System;
using System.Collections.Generic;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class Entity
    {
        public Entity()
        {
            this.EntityAddresses = new List<EntityAddress>();
        }

        public int EntityId { get; set; }
        public System.Guid RowGuid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Company Company { get; set; }
        public virtual Court Court { get; set; }
        public virtual ICollection<EntityAddress> EntityAddresses { get; set; }
        public virtual Person Person { get; set; }
    }
}
