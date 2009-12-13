using System;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogRequestBinder<T> : IModelBinder where T: MetaBlogRequestBase, new()
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }

            var model = new T();

            try
            {
                model.LoadXml(controllerContext.HttpContext.Request.InputStream);
            }
            catch (Exception)
            {
                throw new HttpException("Invalid Request");
            }

            return model;
        }
    }
}