using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lips.Tool.Parser
{
    public static class XmlSerializator
    {
        // Methods
        public static bool ContractObjectToXml<T>(T obj, ref string text)
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
            using (StringWriter writer = new StringWriter())
            {
                using (XmlWriter writer2 = XmlWriter.Create(writer))
                {
                    serializer.WriteObject(writer2, obj);
                }
                text = writer.ToString();
            }
            if (text != "")
            {
                text.TrimEnd("\0".ToCharArray());
                return true;
            }
            return false;
        }

        public static bool XmlArraySerialize<T>(this T[] value, ref string serializeXml)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                XmlSerializer serializer = new XmlSerializer(value.GetType());
                StringWriter output = new StringWriter();
                XmlWriter xmlWriter = XmlWriter.Create(output);
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "");
                serializer.Serialize(xmlWriter, value, namespaces);
                serializeXml = output.ToString();
                xmlWriter.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool XmlSerialize<T>(this T value, ref string serializeXml)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                XmlSerializer serializer = new XmlSerializer(value.GetType());
                StringWriter output = new StringWriter();
                XmlWriter xmlWriter = XmlWriter.Create(output);
                serializer.Serialize(xmlWriter, value);
                serializeXml = output.ToString();
                xmlWriter.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }


}
