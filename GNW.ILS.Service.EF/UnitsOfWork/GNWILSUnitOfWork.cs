using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using GNW.ILS.Service.EF.Contexts;
using GNW.ILS.Service.Persistence.Exceptions;
using GNW.ILS.Service.Persistence.Repositories;
using GNW.ILS.Service.Persistence.UnitsOfWork;
using TrackableEntities.Patterns.EF6;

namespace GNW.ILS.Service.EF.UnitsOfWork
{
    // Implements IGNWILSUnitOfWork in the Persistence project
    public class GNWILSUnitOfWork : UnitOfWork, IGNWILSUnitOfWork
    {
        // TODO: Add read-only fields for each entity repository interface
        private readonly IAddressTypeRepository _addressTypeRepository;
        

        // TODO: Rename IPharmacyDbContext to match context interface
        // TODO: Add parameters for each repository interface
        public GNWILSUnitOfWork(IGNWILSDbContext context
             , IAddressTypeRepository addressTypeRepository) :
            base(context as DbContext)
        {
            // TODO: Initizlialize each entity repository field
            _addressTypeRepository = addressTypeRepository;
        }

        // TODO: Add read-only property for each entity repository interface
        public IAddressTypeRepository AddressTypeRepository
        {
            get { return _addressTypeRepository; }
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                throw new UpdateConcurrencyException(concurrencyException.Message,
                    concurrencyException);
            }
            catch (DbUpdateException updateException)
            {
                throw new UpdateException(updateException.Message,
                    updateException);
            }
        }

        public override Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync(CancellationToken.None);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                throw new UpdateConcurrencyException(concurrencyException.Message,
                    concurrencyException);
            }
            catch (DbUpdateException updateException)
            {
                throw new UpdateException(updateException.Message,
                    updateException);
            }
        }
    }
}
