using System;
using System.Collections.Generic;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class EmployeeDepartmentHistory
    {
        public int EntityId { get; set; }
        public short DepartmentId { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
