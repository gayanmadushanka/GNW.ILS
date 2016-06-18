using System;
using System.Collections.Generic;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class CourtType
    {
        public CourtType()
        {
            this.Courts = new List<Court>();
        }

        public int CourtTypeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public System.Guid RowGuid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<Court> Courts { get; set; }
    }
}
