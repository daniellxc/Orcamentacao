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
    public class ProjetoAtividadeRiscoBO
    {
        ProjetoAtividadeRiscoDAO _DAO = new ProjetoAtividadeRiscoDAO();


        /// <summary>
        /// Lista todos os riscos
        /// </summary>
        /// <returns></returns>
        public List<ProjetoAtividadeRiscoDTO> GetRiscos()
        {
            return _DAO.GetAll();
        }

        public ProjetoAtividadeRiscoDTO GetRisco(int idRisco)
        {
            return _DAO.Get(idRisco);
        }

        public void SalvarRisco(ProjetoAtividadeRiscoDTO risco)
        {
            try
            {
                if (risco.IdRiscoAtividade == 0)
                {
                    _DAO.Add(risco);
                    _DAO.CommitChanges();
                }
                else
                    _DAO.Update(risco, risco.IdRiscoAtividade);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(risco);
            }
            catch
            {

                throw new Exceptions.ErroAoSalvar(risco);
            }
        }
    }
}
