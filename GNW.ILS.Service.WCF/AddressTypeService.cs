using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ServiceModel;
using System.Threading.Tasks;
using GNW.ILS.Entities.Service.Models;
using GNW.ILS.Service.EF.Contexts;
using GNW.ILS.Service.WCF.Contract;
using TrackableEntities;
using TrackableEntities.Common;
using TrackableEntities.EF6;

namespace GNW.ILS.Service.WCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AddressTypeService : IAddressTypeService, IDisposable
    {
        private readonly GNWILSDbContext _dbContext;

        public AddressTypeService()
        {
            _dbContext = new GNWILSDbContext();
        }

        public async Task<IEnumerable<AddressType>> GetAddressTypes()
        {
            IEnumerable<AddressType> entities = await _dbContext.AddressTypes
                // TODO: Add Includes for reference and/or collection properties
                .ToListAsync();
            return entities;
        }

        public async Task<AddressType> GetAddressType(int id)
        {
            AddressType entity = await _dbContext.AddressTypes
                // TODO: Add Includes for reference and/or collection properties
                .SingleOrDefaultAsync(e => e.AddressTypeId == id);
            return entity;
        }

        public async Task<AddressType> CreateAddressType(AddressType entity)
        {
            entity.TrackingState = TrackingState.Added;
            _dbContext.ApplyChanges(entity);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException updateEx)
            {
                throw new FaultException(updateEx.Message);
            }

            await _dbContext.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return entity;
        }

        public async Task<AddressType> UpdateAddressType(AddressType entity)
        {
            _dbContext.ApplyChanges(entity);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException updateEx)
            {
                throw new FaultException(updateEx.Message);
            }

            await _dbContext.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return entity;
        }

        public async Task<bool> DeleteAddressType(int id)
        {
            AddressType entity = await _dbContext.AddressTypes
                // TODO: Include child entities if any
                .SingleOrDefaultAsync(e => e.AddressTypeId == id);
            if (entity == null)
                return false;

            entity.TrackingState = TrackingState.Deleted;
            _dbContext.ApplyChanges(entity);

            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException updateEx)
            {
                throw new FaultException(updateEx.Message);
            }
        }

        public void Dispose()
        {
            var dispose = _dbContext as IDisposable;
            if (dispose != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
