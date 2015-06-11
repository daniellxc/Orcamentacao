using Conductor.Orcamentacao.Web.Acessorio;
using DAL.Classes.BO;
using DAL.Classes.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Conductor.Orcamentacao.Web.Controllers
{
    public class AtividadeController : CustomController
    {
        // GET: Atividade
        ProjetoAtividadeBO _DAO = new ProjetoAtividadeBO();



        public ActionResult Index(int idRequisito)
        {
            return View(idRequisito);
        }

        public ActionResult CadastrarAtividade()
        {
            return View();
        }

        public ActionResult SalvarAtividade(ProjetoAtividadeDTO atividade)
        {
            if (!ModelState.IsValid)
                return View("CadastrarAtividade",atividade);
            try
            {
                bool edit = atividade.IdAtividade != 0;
                _DAO.Salvar(atividade);
                if (edit)
                    return RedirectToAction("Index", "Atividade", new { idRequisito = atividade.IdRequisito }).ComMensagemDeSucesso(Mensagem.GetMensagem(this.ToString(),"Atualizar"));
                return RedirectToAction("CadastrarAtividade").ComMensagemDeSucesso(Mensagem.GetMensagem(this.ToString(),"SalvarAtividade"));
            }
            catch(Exception ex)
            {
                return View("CadastrarAtividade", atividade).ComMensagemDeErro(ex.Message);
            }
        }

        public ActionResult Editar(int idAtividade)
        {
            return View("CadastrarAtividade", _DAO.GetAtividade(idAtividade));
        }

        public ActionResult GerarRelatorios(string idProjeto)
        {
            return View();
        }

        public ActionResult EstimativaProjeto(string idProjeto)
        {

            return View(int.Parse(idProjeto));
        }


        public ActionResult Excluir(int idAtividade)
        {
            int idRequisito = _DAO.GetAtividade(idAtividade).IdRequisito;
            try
            {
 
                _DAO.ExcluirAtividade(_DAO.GetAtividade(idAtividade));
                return View("Index", idRequisito);
            }
            catch(Exception ex)
            {
                return View("Index", idRequisito).ComMensagemDeErro(ex.Message);
            }

        }

       


        public JsonResult GetRequisitos(string id)
        {
          
            if (id == "")
                id = "0";
            return Json(new SelectList(new ProjetoRequisitoBO().GetRequisitosDoProjeto(int.Parse(id)),"IdRequisito","Descricao"));

        }
    }
}