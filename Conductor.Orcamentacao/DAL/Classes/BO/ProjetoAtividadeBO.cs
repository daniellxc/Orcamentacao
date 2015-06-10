using DAL.Classes.DAO;
using DAL.Classes.DTO;
using DAL.Classes.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.BO
{
    public class ProjetoAtividadeBO
    {
        ProjetoAtividadeDAO _DAO = new ProjetoAtividadeDAO();

        public List<ProjetoAtividadeDTO> ListarAtididadesPorProjeto(int idProjeto)
        {
            return _DAO.Find(a => a.FK_Requisito.IdProjeto == idProjeto).ToList<ProjetoAtividadeDTO>();
        }

        public List<ProjetoAtividadeDTO> ListarAtididadesPorRequisito(int idRequisito)
        {
            return _DAO.Find(a => a.IdRequisito == idRequisito).ToList<ProjetoAtividadeDTO>();
        }

        public ProjetoAtividadeDTO GetAtividade(int idAtividade)
        {
            return _DAO.Get(idAtividade);
        }


        public void Salvar(ProjetoAtividadeDTO _atividade)
        {
            try
            {
                if (_atividade.IdAtividade == 0)
                {
                    _DAO.Add(_atividade);
                    _DAO.CommitChanges();
                }
                else
                    _DAO.Update(_atividade, _atividade.IdAtividade);
            }
            catch(DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(_atividade);
            }
            catch
            {
                throw new Exceptions.ErroAoSalvar(_atividade);
            }
        }

        public void ExcluirAtividade(ProjetoAtividadeDTO atividade)
        {
            try
            {
                _DAO.Delete(atividade);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoExcluir(atividade);
            }
            catch
            {
                throw new Exceptions.ErroDesconhecido();
            }
        }
    }
}
