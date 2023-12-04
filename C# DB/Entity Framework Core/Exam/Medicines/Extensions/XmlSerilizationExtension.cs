using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Medicines.Extensions
{
    public static class XmlSerializationExtension
    {
        public static string SerializeToXml<T>(this T obj, string rootName)
        {
            var xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            string result = null;

            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = "\n",
                    OmitXmlDeclaration = false, // Include XML declaration
                    Encoding = Encoding.UTF8, // Set encoding to UTF-8
                };

                using (XmlWriter writer = XmlWriter.Create(ms, settings))
                {
                    xmlSerializer.Serialize(writer, obj, namespaces);
                }

                // Convert the MemoryStream to a string using UTF-8 encoding
                ms.Position = 0; // Reset the stream position before reading
                using (StreamReader reader = new StreamReader(ms, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }

        public static T Deserialize<T>(string inputXml, string rootName)
        {
            if (string.IsNullOrEmpty(inputXml))
                throw new ArgumentException("Input XML cannot be null or empty.", nameof(inputXml));

            if (string.IsNullOrEmpty(rootName))
                throw new ArgumentException("Root name cannot be null or empty.", nameof(rootName));

            try
            {
                XmlRootAttribute xmlRoot = new(rootName);
                XmlSerializer xmlSerializer = new(typeof(T), xmlRoot);

                using var reader = new StringReader(inputXml);
                return (T)xmlSerializer.Deserialize(reader);
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex);
                throw new InvalidOperationException("XML deserialization failed.", ex);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex);
                throw new InvalidOperationException($"{typeof(T)} deserialization failed.", ex);
            }
        }
    }
}
