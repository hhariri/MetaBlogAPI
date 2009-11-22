using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public abstract class MetaBlogBase
    {
        protected IList<XElement> ParamNodes;

        public string AppKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual void SetProperties(XDocument data)
        {
        }

        public void LoadXml(XDocument data)
        {
            ParamNodes = data.Element("methodCall").Element("params").Elements("param").ToList();

            if (ParamNodes != null)
            {
                AppKey = ParamNodes[0].Element("value").Element("string").Value;
                Username = ParamNodes[1].Element("value").Element("string").Value;
                Password = ParamNodes[2].Element("value").Element("string").Value;
            }
            SetProperties(data);    
        }
        
        public void LoadXml(Stream data)
        {
            LoadXml(XDocument.Load(XmlReader.Create(data)));
        }
    }
}