using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TrackableEntities;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class AddressType : ITrackable, IMergeable
    {
        public AddressType()
        {
            this.EntityAddresses = new List<EntityAddress>();
        }

        public int AddressTypeId { get; set; }
        public string Name { get; set; }
        public System.Guid RowGuid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public ICollection<EntityAddress> EntityAddresses { get; set; }

        [NotMapped]
        public TrackingState TrackingState { get; set; }

        [NotMapped]
        public ICollection<string> ModifiedProperties { get; set; }

        [NotMapped]
        public Guid EntityIdentifier { get; set; }
    }
}
