using GNW.ILS.Service.Persistence.Repositories;
using TrackableEntities.Patterns;

namespace GNW.ILS.Service.Persistence.UnitsOfWork
{
    public interface IGNWILSUnitOfWork : IUnitOfWork, IUnitOfWorkAsync
    {
        IAddressTypeRepository AddressTypeRepository { get; }
    }
}
