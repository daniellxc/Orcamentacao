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
    public class RecursoBO
    {
        RecursoDAO _DAO = new RecursoDAO();

        /// <summary>
        /// Lista todos os recursos
        /// </summary>
        /// <returns></returns>
        public List<RecursoDTO> GetRecursos()
        {
            return _DAO.GetAll();
        }

        /// <summary>
        /// Lista todos os recursos ativos
        /// </summary>
        /// <returns></returns>
        public List<RecursoDTO> GetRecursosAtivos()
        {
            return _DAO.Find(r => r.Ativo).ToList<RecursoDTO>();
        }

        public void SalvarRecurso(RecursoDTO recurso)
        {
            try
            {
                if (recurso.IdRecurso == 0)
                {
                    _DAO.Add(recurso);
                    _DAO.CommitChanges();
                }
                else
                    _DAO.Update(recurso, recurso.IdRecurso);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(recurso);
            }
            catch
            {

                throw new Exceptions.ErroAoSalvar(recurso);
            }
        }

        public RecursoDTO GetRecurso(int idRecurso)
        {
            return _DAO.Get(idRecurso);
        }

        public void ExcluirRecurso(RecursoDTO recurso)
        {
            try
            {
                _DAO.Delete(recurso);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoExcluir(recurso);
            }
            catch
            {
                throw new Exceptions.ErroDesconhecido();
            }
           

        }
    }
}
