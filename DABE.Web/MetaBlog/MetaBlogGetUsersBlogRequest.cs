using System;
using System.Linq;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogGetUsersBlogRequest: MetaBlogBase
    {
        public string BlogId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override void Load(XDocument data)
        {
            var paramNodes = data.Element("methodCall").Element("params").Elements("param").ToList();

            if (paramNodes != null)
            {
                BlogId = paramNodes[0].Element("value").Element("string").Value;
                Username = paramNodes[1].Element("value").Element("string").Value;
                Password = paramNodes[2].Element("value").Element("string").Value;
            }
        }
    }
}