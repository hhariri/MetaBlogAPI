using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public static class XmlRpcSerializer
    {
        public static XDocument ToXmlStructResponse(Dictionary<string, object> data)
        {
            return ToXmlResponse(ToXmlStruct(data));
        }

        public static XDocument ToXmlArrayResponse(IList<Dictionary<string, object>> data)
        {
            return ToXmlResponse(ToXmlArray(data));
        }


        public static XDocument ToXmlPrimitiveResponse(object data)
        {
            return ToXmlResponse(ToXmlElement(data));
        }

        public static XDocument ToXmlPrimitiveResponse(object data, string typeName)
        {
            return ToXmlResponse(ToXmlElement(data, typeName));
        }

        public static XDocument ToXmlFault(Dictionary<string, object> data)
        {
            return new XDocument(
                        new XElement("methodResponse",
                            new XElement("fault",
                                new XElement("value",
                                    ToXmlStruct(data)))));
        }

        static XElement ToXmlStruct(Dictionary<string, object> data)
        {
            return  
                        new XElement("struct",
                            from member in data
                            select new XElement("member",
                                new XElement("name", member.Key),
                                new XElement("value", member.Value)
                    ));

    
        }

        static XElement ToXmlArray(IEnumerable<Dictionary<string, object>> data)
        {
            return new XElement("array",
                                new XElement("data",
                                             from element in data
                                             select
                                                 new XElement("value", ToXmlStruct(element))));
            
        }

        static XElement ToXmlElement(object data)
        {   
            return new XElement(data.GetType().Name.ToLower(), data);
        }

        static XElement ToXmlElement(object data, string typeName)
        {
            return new XElement(typeName, data);
        }

        static XDocument ToXmlResponse(XElement data)
        {
            return new XDocument(
                        new XElement("methodResponse",
                            new XElement("params",
                                new XElement("param", 
                                    new XElement("value", data)))));
        }

       

    }
}
