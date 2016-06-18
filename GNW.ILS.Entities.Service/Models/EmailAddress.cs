using System;
using System.Collections.Generic;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class EmailAddress
    {
        public int EntityId { get; set; }
        public int EmailAddressId { get; set; }
        public string EmailAddress1 { get; set; }
        public System.Guid RowGuid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual Person Person { get; set; }
    }
}
