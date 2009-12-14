using System.Collections.Generic;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogGetCategoriesRequest: MetaBlogRequestCommon
    {
        public MetaBlogGetCategoriesRequest(IList<XElement> paramNodes) : base(paramNodes)
        {
        }

        public string BlogId { get; set; }

        public override void SetProperties(IList<XElement> paramNodes)
        {
            BlogId = paramNodes[0].Element("value").Element("string").Value;
            Username = paramNodes[1].Element("value").Element("string").Value;
            Password = paramNodes[2].Element("value").Element("string").Value;
        }
    }
}