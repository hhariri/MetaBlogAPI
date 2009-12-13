using System;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogEditPostRequest : MetaBlogRequestBase
    {
        public string PostId { get; set; }
        public string Content { get; set; }
        public bool Publish { get; set; }

        public override void SetProperties(XDocument data)
        {
            AppKey = ParamNodes[0].Element("value").Element("string").Value;
            PostId = ParamNodes[1].Element("value").Element("string").Value;
            Username = ParamNodes[2].Element("value").Element("string").Value;
            Password = ParamNodes[3].Element("value").Element("string").Value;
            Content = ParamNodes[4].Element("value").Element("string").Value;
            Publish = Convert.ToBoolean(ParamNodes[5].Element("value").Element("boolean").Value);
        }
    }
}