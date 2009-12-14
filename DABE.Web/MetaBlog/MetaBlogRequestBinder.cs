using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace DABE.Web.MetaBlog
{

    public class MetaBlogRequestBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }

            try
            {
                var model = new MetaBlogRequest(controllerContext.HttpContext.Request.InputStream);

                return model;
            }
            catch (Exception)
            {
                throw new HttpException("Invalid Request");
            }

            
        }
    }
}