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
    public class ParametroSistemaBO
    {

        ParametroSistemaDAO _DAO = new ParametroSistemaDAO();

        /// <summary>
        /// Obs.:para parametros cadastrados sem nome, o nome do método será atribuido ao campo "nome"
        /// </summary>
        /// <param name="parametroSistema"></param>
        public void Salvar(ParametroSistemaDTO parametroSistema)
        {
            try
            {
                //para parametros cadastrados sem nome, o nome do método será atribuido ao campo "nome"
                if (parametroSistema.Nome.Trim().Equals(string.Empty))
                    parametroSistema.Nome = parametroSistema.Metodo;


                if (parametroSistema.IdParametroSistema == 0)
                {
                    _DAO.Add(parametroSistema);
                    _DAO.CommitChanges();
                }
                else
                    _DAO.Update(parametroSistema, parametroSistema.IdParametroSistema);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoSalvar(parametroSistema);

            }catch{throw new Exceptions.ErroDesconhecido();}
        }

        /// <summary>
        /// Retorno um parametro dado o nome da classe e o método, independente de estar ativo ou não
        /// </summary>
        /// <param name="classe"></param>
        /// <param name="metodo"></param>
        public ParametroSistemaDTO GetParametroSistema(string classe, string metodo)
        {
            //para parametros cadastrados sem nome, o nome do método será atribuido ao campo "nome"
            return _DAO.Find(p => p.Classe == classe && p.Metodo == metodo && p.Nome == metodo).Single();
        }

        /// <summary>
        /// Retorno um parâmetro dado o código do parâmetro
        /// </summary>
        /// <param name="idParametroSistema"></param>
        /// <returns></returns>
        public ParametroSistemaDTO GetParametroSistema(int idParametroSistema)
        {
            return _DAO.Get(idParametroSistema);
        }

        public List<ParametroSistemaDTO> ListarTodos()
        {
            return _DAO.GetAll();
        }
    }
}
