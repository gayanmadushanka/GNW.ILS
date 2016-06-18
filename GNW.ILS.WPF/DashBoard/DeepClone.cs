using System.IO;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace Pervation.Presentation.DashBoard
{
    public static class DeepClone
    {
        public static T Clone<T>(this T obj)
        {
            T objectClone;
            var dataContractSerializer = new DataContractSerializer(typeof(T));
            using (var memoryStream = new MemoryStream())
            {
                dataContractSerializer.WriteObject(memoryStream, obj);
                memoryStream.Position = 0;
                objectClone = (T)dataContractSerializer.ReadObject(memoryStream);
            }
            return objectClone;
        }

        public static InkCanvas CloneInkCanvas(this InkCanvas inkCanvas)
        {
            string childXaml = XamlWriter.Save(inkCanvas);
            //Load it into a new object:
            StringReader stringReader = new StringReader(childXaml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            return (InkCanvas)XamlReader.Load(xmlReader);
        }
    }
}
