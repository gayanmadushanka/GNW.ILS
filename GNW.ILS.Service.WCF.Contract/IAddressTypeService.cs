using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using GNW.ILS.Entities.Service.Models;
using WcfSerializationHelper;

namespace GNW.ILS.Service.WCF.Contract
{
    [ServiceContract(Namespace = "urn:trackable-entities:service")]
    [DataContractSerializerPreserveReferences] // Configure serializer to handle cyclical references
    public interface IAddressTypeService
    {
        [OperationContract]
        Task<IEnumerable<AddressType>> GetAddressTypes();

        [OperationContract]
        Task<AddressType> GetAddressType(int id);

        [OperationContract]
        Task<AddressType> UpdateAddressType(AddressType entity);

        [OperationContract]
        Task<AddressType> CreateAddressType(AddressType entity);

        [OperationContract]
        Task<bool> DeleteAddressType(int id);
    }
}

