using Conductor.Orcamentacao.Web.Acessorio;
using DAL.Classes.BO;
using DAL.Classes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Conductor.Orcamentacao.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            List<MethodInfo> l = Apoio.GetMetodos("AtividadeController");
            //Type t = Type.GetType("Conductor.Orcamentacao.Web.Controllers.AtividadeController");
           // MethodInfo[] t = Type.GetType("Atividade").GetMethods() ;

            List<string> o = Apoio.GetClasses();
            return View();
        }
    }
}