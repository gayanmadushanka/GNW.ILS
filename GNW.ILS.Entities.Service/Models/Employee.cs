using System;
using System.Collections.Generic;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class Employee
    {
        public Employee()
        {
            this.EmployeeDepartmentHistories = new List<EmployeeDepartmentHistory>();
        }

        public int EntityId { get; set; }
        public string NationalIdNumber { get; set; }
        public string LoginID { get; set; }
        public Nullable<short> OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public System.DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public System.Guid RowGuid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
    }
}
