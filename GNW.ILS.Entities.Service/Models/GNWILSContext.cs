using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GNW.ILS.Entities.Service.Models.Mapping;

namespace GNW.ILS.Entities.Service.Models
{
    public partial class GNWILSContext : DbContext
    {
        static GNWILSContext()
        {
            Database.SetInitializer<GNWILSContext>(null);
        }

        public GNWILSContext()
            : base("Name=GNWILSContext")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<CourtType> CourtTypes { get; set; }
        public DbSet<DatabaseLog> DatabaseLogs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<EntityAddress> EntityAddresses { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

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
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
