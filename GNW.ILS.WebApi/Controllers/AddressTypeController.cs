using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GNW.ILS.Entities.Service.Models;
using GNW.ILS.Service.Persistence.Exceptions;
using GNW.ILS.Service.Persistence.UnitsOfWork;
using TrackableEntities.Common;

namespace GNW.ILS.WebApi.Controllers
{
    public class AddressTypeController : ApiController
    {
        // TODO: Rename IGNWILSUnitOfWork to match Unit of Work Interface added to Persistence project
        private readonly IGNWILSUnitOfWork _unitOfWork;

        // TODO: Rename IGNWILSUnitOfWork parameter
        public AddressTypeController(IGNWILSUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/AddressType
        [ResponseType(typeof(IEnumerable<AddressType>))]
        public async Task<IHttpActionResult> GetAddressTypes()
        {
            IEnumerable<AddressType> entities = await _unitOfWork.AddressTypeRepository.GetAddressTypes();
            return Ok(entities);
        }

        // GET api/AddressType/5
        [ResponseType(typeof(AddressType))]
        public async Task<IHttpActionResult> GetAddressType(int id)
        {
            AddressType entity = await _unitOfWork.AddressTypeRepository.GetAddressType(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/AddressType
        [ResponseType(typeof(AddressType))]
        public async Task<IHttpActionResult> PostAddressType(AddressType entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.AddressTypeRepository.Insert(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.AddressTypeRepository.Find(entity.AddressTypeId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.AddressTypeRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.AddressTypeId }, entity);
        }

        // PUT api/AddressType
        [ResponseType(typeof(AddressType))]
        public async Task<IHttpActionResult> PutAddressType(AddressType entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.AddressTypeRepository.Update(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.AddressTypeRepository.Find(entity.AddressTypeId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.AddressTypeRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return Ok(entity);
        }

        // DELETE api/AddressType/5
        public async Task<IHttpActionResult> DeleteAddressType(int id)
        {
            bool result = await _unitOfWork.AddressTypeRepository.DeleteAddressType(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.AddressTypeRepository.Find(id) == null)
                {
                    return Conflict();
                }
                throw;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var disposable = _unitOfWork as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
