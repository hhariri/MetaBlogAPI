using System;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogGetUsersBlogRequestBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }

            var xml = XDocument.Load(XmlReader.Create(controllerContext.HttpContext.Request.InputStream));

            var model = new MetaBlogGetUsersBlogRequest();

            model.Load(xml);

            return model;
        }
    }
}