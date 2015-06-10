using Conductor.Orcamentacao.Web.Acessorio;
using DAL.Classes.BO;
using DAL.Classes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conductor.Orcamentacao.Web.Controllers
{
    public class ProjetoController : CustomController
    {
        // GET: Projeto
        ProjetoBO _DAO = new ProjetoBO();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        public ActionResult Editar(int idProjeto)
        {
            return View("Adicionar", _DAO.GetProjeto(idProjeto));
        }

        public ActionResult Excluir(int idProjeto)
        {
            try
            {
                _DAO.ExcluirProjeto(_DAO.GetProjeto(idProjeto));
                return View("Index");
            }
            catch (Exception ex)
            {
                return View("Index").ComMensagemDeErro(ex.Message);
            }
        }

        public ActionResult SalvarProjeto(ProjetoDTO _projeto)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View("Adicionar", _projeto);
                bool edit = _projeto.IdProjeto == 0;
                
                    _DAO.SalvarProjeto(_projeto);
                    if (edit)
                             return View("Index").ComMensagemDeSucesso("Projeto atualizado com sucesso!");
                    return View("Index").ComMensagemDeSucesso("Novo projeto adicionado!");
            }
            catch
            {
                return View("Adicionar",_projeto);
            }
        }
    }
}