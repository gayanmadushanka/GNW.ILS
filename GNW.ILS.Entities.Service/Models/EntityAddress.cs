using System;
using System.Collections.Generic;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class EntityAddress
    {
        public int EntityId { get; set; }
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public System.Guid RowGuid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual Address Address { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual Entity Entity { get; set; }
    }
}
