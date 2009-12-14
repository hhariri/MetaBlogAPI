using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public abstract class MetaBlogRequestCommon
    {
        public string AppKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual void SetProperties(IList<XElement> paramNodes)
        {
        }

        public MetaBlogRequestCommon(IList<XElement> paramNodes)
        {
            if (paramNodes != null)
            {
                AppKey = paramNodes[0].Element("value").Element("string").Value;
                Username = paramNodes[1].Element("value").Element("string").Value;
                Password = paramNodes[2].Element("value").Element("string").Value;
            }
            SetProperties(paramNodes);
        }

    }
}