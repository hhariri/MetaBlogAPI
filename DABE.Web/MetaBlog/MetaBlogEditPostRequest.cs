using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogEditPostRequest : MetaBlogRequestCommon
    {
        public MetaBlogEditPostRequest(IList<XElement> paramNodes) : base(paramNodes)
        {
        }

        public string PostId { get; set; }
        public string Content { get; set; }
        public bool Publish { get; set; }

        public override void SetProperties(IList<XElement> paramNodes)
        {
            AppKey = paramNodes[0].Element("value").Element("string").Value;
            PostId = paramNodes[1].Element("value").Element("string").Value;
            Username = paramNodes[2].Element("value").Element("string").Value;
            Password = paramNodes[3].Element("value").Element("string").Value;
            Content = paramNodes[4].Element("value").Element("string").Value;
            Publish = Convert.ToBoolean(paramNodes[5].Element("value").Element("boolean").Value);
        }
    }
}