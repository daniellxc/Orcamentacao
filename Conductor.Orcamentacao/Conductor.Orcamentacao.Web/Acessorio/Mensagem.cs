using DAL.Classes.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conductor.Orcamentacao.Web.Acessorio
{
    public class Mensagem
    {
        static ParametroSistemaBO parametros = new ParametroSistemaBO();


        public static string GetMensagem(string classe, string metodo)
        {
            try
            {
                return parametros.GetParametroSistema(classe, metodo).Valor;
            }
            catch
            {
                return "nenhuma mensagem cadastrada";
            }
            
        }
    }
}