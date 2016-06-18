using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WcfSerializationHelper
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Method)]
    public class DataContractSerializerPreserveReferencesAttribute :
        Attribute, IOperationBehavior, IContractBehavior
    {
        public void AddBindingParameters(OperationDescription operation, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, 
            ClientOperation clientOperation)
        {
            ReplaceDataContractSerializerOperationBehavior(operationDescription);
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, 
            DispatchOperation dispatchOperation)
        {
            ReplaceDataContractSerializerOperationBehavior(operationDescription);
        }

        public void Validate(OperationDescription operationDescription)
        {
        }

        private void ReplaceDataContractSerializerOperationBehavior(OperationDescription operationDescription)
        {
            if (operationDescription.Behaviors.Remove(typeof(DataContractSerializerOperationBehavior)) || operationDescription.Behaviors.Remove(typeof(DataContractSerializerPreserveReferencesOperationBehavior)))
            {
                operationDescription.Behaviors.Add(new DataContractSerializerPreserveReferencesOperationBehavior(operationDescription));
            }
        }

        public void AddBindingParameters(ContractDescription contractDescription, 
            ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, 
            ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            ReplaceDataContractSerializerOperationBehaviors(contractDescription);
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, 
            ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            ReplaceDataContractSerializerOperationBehaviors(contractDescription);
        }

        public void Validate(ContractDescription contractDescription, 
            ServiceEndpoint endpoint)
        {
        }

        private void ReplaceDataContractSerializerOperationBehaviors(
            ContractDescription contractDescription)
        {
            foreach (var operation in contractDescription.Operations)
            {
                ReplaceDataContractSerializerOperationBehavior(operation);
            }
        }
    }
}
