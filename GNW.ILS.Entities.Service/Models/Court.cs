using System;
using System.Collections.Generic;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class Court
    {
        public int EntityId { get; set; }
        public int CourtTypeId { get; set; }
        public string Name { get; set; }
        public System.Guid RowGuid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual CourtType CourtType { get; set; }
        public virtual Entity Entity { get; set; }
    }
}
