using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;

namespace WcfSerializationHelper
{
    public class DataContractSerializerPreserveReferencesOperationBehavior :
        DataContractSerializerOperationBehavior
    {
        public DataContractSerializerPreserveReferencesOperationBehavior(OperationDescription operation) 
            : base(operation)
        {
        }

        public DataContractSerializerPreserveReferencesOperationBehavior(
            OperationDescription operation, DataContractFormatAttribute dataContractFormatAttribute)
            : base(operation, dataContractFormatAttribute)
        {
        }

        public override XmlObjectSerializer CreateSerializer(
            Type type, string name, string ns, IList<Type> knownTypes)
        {
            var serializer = new DataContractSerializer(type, name, ns, knownTypes, 
                int.MaxValue, false, true, null);
            return serializer;
        }

        public override XmlObjectSerializer CreateSerializer(
            Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            var serializer = new DataContractSerializer(type, name, ns, knownTypes, 
                int.MaxValue, false, true, null);
            return serializer;
        }
    }
}
