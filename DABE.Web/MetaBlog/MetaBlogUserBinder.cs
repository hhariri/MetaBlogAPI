using System;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogUserBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }

            var xml = XDocument.Load(XmlReader.Create(controllerContext.HttpContext.Request.InputStream));

            var paramNodes = xml.Element("methodCall").Element("params").Elements("param").ToList();
            
            var model = new MetaBlogUser();

            if (paramNodes != null)
            {
                model.BlogId = paramNodes[0].Element("value").Element("string").Value;
                model.Username = paramNodes[1].Element("value").Element("string").Value;
                model.Password = paramNodes[2].Element("value").Element("string").Value;
            }

            return model; 
        }
    }
}