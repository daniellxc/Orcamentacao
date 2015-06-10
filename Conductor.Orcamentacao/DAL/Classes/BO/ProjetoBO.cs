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
    public class ProjetoBO
    {
        ProjetoDAO _DAO = new ProjetoDAO();


        public ProjetoDTO GetProjeto(int IdProjeto)
        {
            return _DAO.Get(IdProjeto);
        }

        public List<ProjetoDTO> ListarProjetos()
        {
            return _DAO.GetAll();
        }

     
        public void ExcluirProjeto(ProjetoDTO projeto)
        {
            try
            {
                _DAO.Delete(projeto);
            }
            catch
            { 
                throw; 
            }
        }
        

        public void SalvarProjeto(ProjetoDTO projeto)
        {
            try
            {
                if (projeto.IdProjeto == 0)
                {
                    _DAO.Add(projeto);
                    _DAO.CommitChanges();
                }
                else
                    _DAO.Update(projeto, projeto.IdProjeto);
                   
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(projeto);
            }
            catch
            {

                throw new Exceptions.ErroAoSalvar(projeto);
            }
           

        }
    }
}
