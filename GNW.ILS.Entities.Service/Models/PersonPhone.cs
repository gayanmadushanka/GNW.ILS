using System;
using System.Collections.Generic;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class PersonPhone
    {
        public int EntityId { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual Person Person { get; set; }
        public virtual PhoneNumberType PhoneNumberType { get; set; }
    }
}
