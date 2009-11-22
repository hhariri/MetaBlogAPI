using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogSetTemplateRequest: MetaBlogGetTemplateRequest
    {
        public string Template { get; set; }

        public override void SetProperties(XDocument data)
        {
            AppKey = ParamNodes[0].Element("value").Element("string").Value;
            BlogId = ParamNodes[1].Element("value").Element("string").Value;
            Username = ParamNodes[2].Element("value").Element("string").Value;
            Password = ParamNodes[3].Element("value").Element("string").Value;
            Template = ParamNodes[4].Element("value").Element("string").Value;
            TemplateType = ParamNodes[5].Element("value").Element("string").Value;
        }

    }
}