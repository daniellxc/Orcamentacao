using Conductor.Orcamentacao.Web.Acessorio;
using DAL.Classes.BO;
using DAL.Classes.DTO;
using DAL.Classes.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conductor.Orcamentacao.Web.Controllers
{
    public class ParametroSistemaController : Controller
    {
        // GET: ParametroSistema
        ParametroSistemaBO _DAO = new ParametroSistemaBO();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CadastrarParametro()
        {
            return View();
        }

        public ActionResult SalvarParametro(ParametroSistemaDTO parametroSistema)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("CadastrarParametro");

                _DAO.Salvar(parametroSistema);
                return View("Index");
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoSalvar(Mensagem.GetMensagem(this.ToString(), "SalvarParametro"));
            }
        }
    }
}