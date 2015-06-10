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
    public class TipoParametroSistemaBO
    {
        TipoParametroSistemaDAO _DAO = new TipoParametroSistemaDAO();


        public List<TipoParametroSistemaDTO> ListarTodos()
        {
            return _DAO.GetAll();
        }

        public List<TipoParametroSistemaDTO> ListarAtivos()
        {
            return ListarTodos().Where(a => a.Ativo).ToList();
        }

        public void SalvarTipoParametroSistema(TipoParametroSistemaDTO tipoParametro)
        {
            try
            {
                if (tipoParametro.IdTipoParametroSistema == 0)
                {

                    _DAO.Add(tipoParametro);
                    _DAO.CommitChanges();
                }
                    
                else
                    _DAO.Update(tipoParametro, tipoParametro.IdTipoParametroSistema);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoSalvar(tipoParametro);
            }
            catch
            {
                throw new Exceptions.ErroDesconhecido();
            }
        }

        public void AtivarTipoParametro(TipoParametroSistemaDTO tipoParametro, bool ativo)
        {
            try
            {
                tipoParametro.Ativo = ativo;
                _DAO.Update(tipoParametro, tipoParametro.IdTipoParametroSistema);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(tipoParametro);
            }
            catch { throw new Exceptions.ErroDesconhecido(); }
            
        }
    }
}
