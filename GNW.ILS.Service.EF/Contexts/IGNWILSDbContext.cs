using System.Data.Entity;
using GNW.ILS.Entities.Service.Models;

namespace GNW.ILS.Service.EF.Contexts
{
    public interface IGNWILSDbContext
    {
        IDbSet<Address> Addresses { get; set; }
        IDbSet<AddressType> AddressTypes { get; set; }
        IDbSet<Branch> Branches { get; set; }
        IDbSet<Company> Companies { get; set; }
        IDbSet<Court> Courts { get; set; }
        IDbSet<CourtType> CourtTypes { get; set; }
        IDbSet<DatabaseLog> DatabaseLogs { get; set; }
        IDbSet<Department> Departments { get; set; }
        IDbSet<EmailAddress> EmailAddresses { get; set; }
        IDbSet<Employee> Employees { get; set; }
        IDbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        IDbSet<Entity> Entities { get; set; }
        IDbSet<EntityAddress> EntityAddresses { get; set; }
        IDbSet<ErrorLog> ErrorLogs { get; set; }
        IDbSet<Person> People { get; set; }
        IDbSet<PersonPhone> PersonPhones { get; set; }
        IDbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
    }
}
