using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using GNW.ILS.Entities.Service.Models;
using GNW.ILS.Service.EF.Contexts;
using GNW.ILS.Service.Persistence.Repositories;
using TrackableEntities.Patterns.EF6;

namespace GNW.ILS.Service.EF.Repositories
{
    // NOTE: IAddressTypeRepository will need to have been added to the Service.Persistence project

    public class AddressTypeRepository : Repository<AddressType>, IAddressTypeRepository
    {
        // TODO: Match Database Context Interface type
        private readonly IGNWILSDbContext _context;

        // TODO: Match Database Context Interface type
        public AddressTypeRepository(IGNWILSDbContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressType>> GetAddressTypes()
        {
            // TODO: Add Includes for related entities if needed
            IEnumerable<AddressType> entities = await _context.AddressTypes
                .ToListAsync();
            return entities;
        }

        public async Task<AddressType> GetAddressType(int id)
        {
            // TODO: Add Includes for related entities if needed
            AddressType entity = await _context.AddressTypes
                 .SingleOrDefaultAsync(t => t.AddressTypeId == id);
            return entity;
        }

        public async Task<bool> DeleteAddressType(int id)
        {
            // TODO: Add Includes for related entities if needed
            AddressType entity = await _context.AddressTypes
                 .SingleOrDefaultAsync(t => t.AddressTypeId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
