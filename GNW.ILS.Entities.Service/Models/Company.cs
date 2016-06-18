using System;
using System.Collections.Generic;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class Company
    {
        public Company()
        {
            this.Branches = new List<Branch>();
        }

        public int EntityId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool ActiveFlag { get; set; }
        public string WebServiceUrl { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual Entity Entity { get; set; }
    }
}
