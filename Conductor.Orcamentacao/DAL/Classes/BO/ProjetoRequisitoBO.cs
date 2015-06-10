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
    public class ProjetoRequisitoBO
    {
        ProjetoRequisitoDAO _DAO = new ProjetoRequisitoDAO();

        /// <summary>
        /// Lista todos os requisitos
        /// </summary>
        /// <returns></returns>
        public List<ProjetoRequisitoDTO> GetRequisitos()
        {
            return _DAO.GetAll();
        }

        public List<ProjetoRequisitoDTO> GetRequisitosDoProjeto(int idProjeto)
        {
            var ret = from d in (_DAO.Find(r => r.IdProjeto == idProjeto).ToList<ProjetoRequisitoDTO>())
                      select new ProjetoRequisitoDTO { IdRequisito = d.IdRequisito, Descricao = d.IdInterno + "-" + d.Descricao, IdInterno=d.IdInterno};

            return ret.ToList<ProjetoRequisitoDTO>();
        }
      

        public void SalvarRequisito(ProjetoRequisitoDTO requisito)
        {
            try
            {
                if (requisito.IdRequisito == 0)
                {
                    _DAO.Add(requisito);
                    _DAO.CommitChanges();
                }
                else
                    _DAO.Update(requisito, requisito.IdRequisito);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(requisito);
            }
            catch
            {

                throw new Exceptions.ErroAoSalvar(requisito);
            }
        }

        public ProjetoRequisitoDTO GetRequisito(int idRequisito)
        {
            return _DAO.Get(idRequisito);
        }

        public void ExcluirRequisito(ProjetoRequisitoDTO requisito)
        {
            try
            {
                _DAO.Delete(requisito);
            }
            catch(DbUpdateException)
            {
                throw new Exceptions.ErroAoExcluir(requisito);
            }
            catch
            {
                throw new Exceptions.ErroDesconhecido();
            }
        }

    }
}
