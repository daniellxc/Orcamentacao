using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conductor.Orcamentacao.Web.Controllers
{
    public class ParametroSistemaController : Controller
    {
        // GET: ParametroSistema
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CadastrarParametro()
        {
            return View();
        }
    }
}