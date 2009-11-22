using System;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogRequestBinder<T> : IModelBinder where T: MetaBlogBase, new()
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }

            var model = new T();

            model.LoadXml(controllerContext.HttpContext.Request.InputStream);

            return model;
        }
    }
}