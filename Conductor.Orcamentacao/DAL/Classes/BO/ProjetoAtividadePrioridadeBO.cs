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
    public class ProjetoAtividadePrioridadeBO
    {
        ProjetoAtividadePrioridadeDAO _DAO = new ProjetoAtividadePrioridadeDAO();

        /// <summary>
        /// Lista todas as prioridades
        /// </summary>
        /// <returns></returns>
        public List<ProjetoAtividadePrioridadeDTO> GetPrioridades()
        {
            return _DAO.GetAll();
        }

        public void SalvarPrioridade(ProjetoAtividadePrioridadeDTO prioridade)
        {
            try
            {
                if (prioridade.IdPrioridadeAtividade == 0)
                {
                    _DAO.Add(prioridade);
                    _DAO.CommitChanges();
                }
                else
                    _DAO.Update(prioridade, prioridade.IdPrioridadeAtividade);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(prioridade);
            }
            catch
            {

                throw new Exceptions.ErroAoSalvar(prioridade);
            }
        }
    }
}
