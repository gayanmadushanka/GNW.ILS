using System.Data.Entity;
using GNW.ILS.Entities.Service.Models;
using GNW.ILS.Entities.Service.Models.Mapping;

namespace GNW.ILS.Service.EF.Contexts
{
    public partial class GNWILSDbContext : DbContext, IGNWILSDbContext
    {
        static GNWILSDbContext()
        {
            Database.SetInitializer<GNWILSDbContext>(null);
        }

        public GNWILSDbContext()
            : base("Name=GNWILSContext")
        {
        }

        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<AddressType> AddressTypes { get; set; }
        public IDbSet<Branch> Branches { get; set; }
        public IDbSet<Company> Companies { get; set; }
        public IDbSet<Court> Courts { get; set; }
        public IDbSet<CourtType> CourtTypes { get; set; }
        public IDbSet<DatabaseLog> DatabaseLogs { get; set; }
        public IDbSet<Department> Departments { get; set; }
        public IDbSet<EmailAddress> EmailAddresses { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        public IDbSet<Entity> Entities { get; set; }
        public IDbSet<EntityAddress> EntityAddresses { get; set; }
        public IDbSet<ErrorLog> ErrorLogs { get; set; }
        public IDbSet<Person> People { get; set; }
        public IDbSet<PersonPhone> PersonPhones { get; set; }
        public IDbSet<PhoneNumberType> PhoneNumberTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new AddressTypeMap());
            modelBuilder.Configurations.Add(new BranchMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new CourtMap());
            modelBuilder.Configurations.Add(new CourtTypeMap());
            modelBuilder.Configurations.Add(new DatabaseLogMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new EmailAddressMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new EmployeeDepartmentHistoryMap());
            modelBuilder.Configurations.Add(new EntityMap());
            modelBuilder.Configurations.Add(new EntityAddressMap());
            modelBuilder.Configurations.Add(new ErrorLogMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PersonPhoneMap());
            modelBuilder.Configurations.Add(new PhoneNumberTypeMap());
        }
    }
}
