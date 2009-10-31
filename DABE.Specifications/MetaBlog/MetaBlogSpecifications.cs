using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using DABE.Web.MetaBlog;
using Machine.Specifications;
using NHibernate.Mapping;

namespace DABE.Specifications.MetaBlog
{
    public class when_serializing_a_string_to_xmlrpc
    {
        Because of = () =>
        {
            xml = XmlRpcSerializer.ToXmlPrimitiveResponse("hello");
        };

        It should_return_a_simple_value_xmlrpc_packet = () =>
        {
            xml.Element("methodResponse").Element("params").Element("param").Element("value").Element("string").Value.
                ShouldEqual("hello");
        };

        static XDocument xml;
        
    }

    public class when_serializing_a_primitive_type_to_xmlrpc
    {
        Because of = () =>
        {
            xml = XmlRpcSerializer.ToXmlPrimitiveResponse(1, "boolean");
        };

        It should_return_a_simple_value_xmlrpc_packet = () =>
        {
            xml.Element("methodResponse").Element("params").Element("param").Element("value").Element("boolean").Value.
                ShouldEqual("1");

        };

        static XDocument xml;
    }

    public class when_serializing_a_dictionary_to_xmlrpc
    {
        Establish context = () =>
        {
            structure = new Dictionary<string, object>();

            structure.Add("key1", "value1");
            structure.Add("key2", "value2");
        };

        Because of = () =>
        {
            xml = XmlRpcSerializer.ToXmlStructResponse(structure);
        };

        It should_returm_a_struct_xmlrpc_packet = () =>
        {
            xml.Elements("struct").Count().ShouldEqual(1);
            xml.Elements("member").Count().ShouldEqual(2);
            xml.Element("methodResponse").Element("params").Element("param").Element("value").Element("struct").Element(
                "member").Element("name").Value.ShouldEqual("key1");
        };

        static Dictionary<string, object> structure;
        static XDocument xml;
    }
}
