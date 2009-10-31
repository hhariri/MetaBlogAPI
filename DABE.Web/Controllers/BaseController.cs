using System;
using System.Web.Mvc;

namespace DABE.Web.Controllers
{
    public class BaseController: Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            try
            {
                View(actionName).ExecuteResult(ControllerContext);
            }
            catch (InvalidOperationException)
            {
                View("Error").ExecuteResult(ControllerContext);
            }
        }
    }
}