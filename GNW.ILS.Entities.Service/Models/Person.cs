using System;
using System.Collections.Generic;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class Person
    {
        public Person()
        {
            this.EmailAddresses = new List<EmailAddress>();
            this.PersonPhones = new List<PersonPhone>();
        }

        public int EntityId { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.Guid RowGuid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual ICollection<PersonPhone> PersonPhones { get; set; }
    }
}
