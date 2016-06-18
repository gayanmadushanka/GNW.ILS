using System.Collections.Generic;
using System.Threading.Tasks;
using GNW.ILS.Entities.Service.Models;
using TrackableEntities.Patterns;

namespace GNW.ILS.Service.Persistence.Repositories
{
    public interface IAddressTypeRepository : IRepository<AddressType>, IRepositoryAsync<AddressType>
    {
        Task<IEnumerable<AddressType>> GetAddressTypes();
        Task<AddressType> GetAddressType(int id);
        Task<bool> DeleteAddressType(int id);
    }
}
