using System.Collections.Generic;
using System.Xml.Linq;
using DABE.Web.MetaBlog;
using Machine.Specifications;

namespace DABE.Specifications.Web.MetaBlog
{
    public class when_serializing_a_string_to_xmlrpc
    {
        Because of = () =>
                         {
                             xml = XmlRpcSerializer.ToXmlPrimitiveResponse("hello");
                         };

        It should_return_a_simple_value_xmlrpc_packet = () =>
                                                            {
                                                                xml.Element("methodResponse")
                                                                    .Element("params")
                                                                    .Element("param")
                                                                    .Element("value")
                                                                    .Element("string").Value.ShouldEqual("hello"); 
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
                                                                xml.Element("methodResponse")
                                                                    .Element("params")
                                                                    .Element("param")
                                                                    .Element("value")
                                                                    .Element("boolean").Value.ShouldEqual("1");

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

        It should_return_a_struct_xmlrpc_packet = () =>
                                                      {
                                                          xml.Element("methodResponse")
                                                              .Element("params")
                                                              .Element("param")
                                                              .Element("value")
                                                              .Element("struct")
                                                              .Element("member")
                                                              .Element("name").Value.ShouldEqual("key1");
                                                      };

        static Dictionary<string, object> structure;
        static XDocument xml;
    }

    public class when_serializing_a_list_of_dictionaries_to_xmlrpc
    {
        Establish context = () =>
                                {
                                    var structure1 = new Dictionary<string, object> {{"key1", "value1"}, {"key2", "value2"}};

                                    var structure2 = new Dictionary<string, object> {{"key1", "value1"}, {"key2", "value2"}};

                                    array = new List<Dictionary<string, object>> {structure1, structure2};
                                };

        Because of = () =>
                         {
                             xml = XmlRpcSerializer.ToXmlArrayResponse(array);
                         };

        It should_return_an_array_of_struct_xmlrpc_packet = () =>
                                                                {
                                                                    xml.Element("methodResponse")
                                                                        .Element("params")
                                                                        .Element("param")
                                                                        .Element("value")
                                                                        .Element("array")
                                                                        .Element("data")
                                                                        .Element("value")
                                                                        .Element("struct")
                                                                        .Element("member")
                                                                        .Element("name").Value.ShouldEqual("key1");
                                                                };

        static XDocument xml;
        static List<Dictionary<string, object>> array;
    }


    public class when_loading_xml_to_meta_blog_get_user_blogs_request
    {
        Establish context = () =>
                                {
                                    xml =
                                        new XDocument(
                                            new XElement("methodCall",
                                                         new XElement("methodName", "blogger.getUserBlogs"),
                                                         new XElement("params",
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "C6CE3FFB3174106584CBB250C0B0519BF4E294"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "ewilliams"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "secret"))))));
                                };

        Because of = () =>
                         {
                             data = new MetaBlogUserInfoRequest();

                             data.LoadXml(xml);
                         };

        It should_correctly_assign_properties_to_object = () =>
                                                              {
                                                                  data.AppKey.ShouldEqual("C6CE3FFB3174106584CBB250C0B0519BF4E294");
                                                                  data.Username.ShouldEqual("ewilliams");
                                                                  data.Password.ShouldEqual("secret");
                                                              };

        static MetaBlogUserInfoRequest data;
        static XDocument xml;
    }


    public class when_loading_xml_to_meta_blog_new_post_request
    {
        Establish context = () =>
                                {
                                    xml =
                                        new XDocument(
                                            new XElement("methodCall",
                                                         new XElement("methodName", "blogger.newPost"),
                                                         new XElement("params",
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "C6CE3FFB3174106584CBB250C0B0519BF4E294"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "744145"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "ewilliams"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "secret"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "Today I had a peanut butter.....Please comment!"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("boolean", "false"))))));
                                };

        Because of = () =>
                         {
                             data = new MetaBlogNewPostRequest();

                             data.LoadXml(xml);
                         };

        It should_correctly_assign_properties_to_object = () =>
                                                              {
                                                                  data.AppKey.ShouldEqual("C6CE3FFB3174106584CBB250C0B0519BF4E294");
                                                                  data.BlogId.ShouldEqual("744145");
                                                                  data.Username.ShouldEqual("ewilliams");
                                                                  data.Password.ShouldEqual("secret");
                                                                  data.Content.ShouldEqual("Today I had a peanut butter.....Please comment!");
                                                                  data.Publish.ShouldEqual(false);
                                                              };

        static MetaBlogNewPostRequest data;
        static XDocument xml;
        

    }

    public class when_loading_xml_to_meta_blog_edit_post_request
    {
        Establish context = () =>
                                {
                                    xml =
                                        new XDocument(
                                            new XElement("methodCall",
                                                         new XElement("methodName", "blogger.newPost"),
                                                         new XElement("params",
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "C6CE3FFB3174106584CBB250C0B0519BF4E294"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "744145"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "ewilliams"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "secret"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("string", "Today I had a peanut butter.....Please comment!"))),
                                                                      new XElement("param",
                                                                                   new XElement("value",
                                                                                                new XElement("boolean", "false"))))));
                                };

        Because of = () =>
                         {
                             data = new MetaBlogEditPostRequest();

                             data.LoadXml(xml);
                         };

        It should_correctly_assign_properties_to_object = () =>
                                                              {
                                                                  data.AppKey.ShouldEqual("C6CE3FFB3174106584CBB250C0B0519BF4E294");
                                                                  data.PostId.ShouldEqual("744145");
                                                                  data.Username.ShouldEqual("ewilliams");
                                                                  data.Password.ShouldEqual("secret");
                                                                  data.Content.ShouldEqual("Today I had a peanut butter.....Please comment!");
                                                                  data.Publish.ShouldEqual(false);
                                                              };

        static MetaBlogEditPostRequest data;
        static XDocument xml;
    }
}