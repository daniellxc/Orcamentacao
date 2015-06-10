using Conductor.Orcamentacao.Web.Acessorio;
using DAL.Classes.BO;
using DAL.Classes.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conductor.Orcamentacao.Web.Controllers
{
    public class RequisitoController : CustomController
    {
        // GET: Requisito
        ProjetoRequisitoBO _DAO = new ProjetoRequisitoBO();

        public ActionResult Index(int idProjeto)
        {
            return View(idProjeto);
        }

        public ActionResult CadastrarRequisito(ProjetoRequisitoDTO requisito)
        {
            return View(requisito);
        }

        public ActionResult SalvarRequisito(ProjetoRequisitoDTO requisito)
        {
            try
            {
                int idAntigo = requisito.IdRequisito;
                if (!ModelState.IsValid)
                    return View("CadastrarRequisito", requisito);
                _DAO.SalvarRequisito(requisito);
                if(idAntigo==0)
                    return RedirectToAction("Index", "Projeto") ;
                return RedirectToAction("Index", "Requisito", new { idProjeto = requisito.IdProjeto }).ComMensagemDeSucesso("Requisito atualizado com sucesso!");
            }
            catch(Exception ex)
            {
                return View("CadastrarRequisito", requisito).ComMensagemDeErro(ex.Message);
            }

        }

        public ActionResult Editar(int idRequisito)
        {
            return View("CadastrarRequisito", _DAO.GetRequisito(idRequisito)); 
        }

        public ActionResult Excluir(int idRequisito)
        {
            int idProjeto = _DAO.GetRequisito(idRequisito).IdProjeto;
            try
            {
               
                _DAO.ExcluirRequisito(_DAO.GetRequisito(idRequisito));
                return View("Index", idProjeto);
            }
            catch(Exception ex)
            {
                return View("Index", idProjeto).ComMensagemDeErro(ex.Message);
            }
          
        }
    }
}