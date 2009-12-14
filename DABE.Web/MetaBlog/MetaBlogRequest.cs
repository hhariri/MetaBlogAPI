using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogRequest
    {
        public string MethodCall { get; set; }
        public IList<XElement> Params { get; set; }

        public MetaBlogRequest()
        {
        }

        public MetaBlogRequest(Stream data)
        {
            var xml = XDocument.Load(XmlReader.Create(data));

            var methodName = xml.Element("methodCall").Element("methodName").Value;

            MethodCall = methodName.Remove(0, methodName.IndexOf('.') + 1);

            Params = xml.Element("methodCall").Element("params").Elements("param").ToList();
            
        }

    }
}