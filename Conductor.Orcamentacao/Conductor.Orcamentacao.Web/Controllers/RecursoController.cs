using DAL.Classes.BO;
using DAL.Classes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conductor.Orcamentacao.Web.Controllers
{
    public class RecursoController : Controller
    {
        // GET: Recurso

        RecursoBO _DAO = new RecursoBO();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        public ActionResult Editar(int idRecurso)
        {
            return View("Adicionar", _DAO.GetRecurso(idRecurso));
        }

        public ActionResult Excluir(int idRecurso)
        {
            try
            {
                _DAO.ExcluirRecurso(_DAO.GetRecurso(idRecurso));
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        public ActionResult SalvarRecurso(RecursoDTO _recurso)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View("Adicionar", _recurso);
                _DAO.SalvarRecurso(_recurso);
                return View("Index");
            }
            catch
            {
                return View("Adicionar", _recurso);
            }
        }
    }
}