using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conductor.Orcamentacao.Web.Acessorio
{
    public class CustomController:Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            
            ModelState.AddModelError("", filterContext.Exception.Message);
            
        }
    }
}