using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Conductor.Orcamentacao.Web.Acessorio
{
    public class Apoio
    {
        public static List<string> GetClasses()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            List<string> namespacelist = new List<string>();
            List<string> classlist = new List<string>();

            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == "Conductor.Orcamentacao.Web.Controllers")
                    namespacelist.Add(type.Name);
            }

            foreach (string classname in namespacelist)
                classlist.Add(classname);

            return classlist;
        }


        public static List<MethodInfo> GetMetodos(string classe)
        {
            List<MethodInfo> retorno = new List<MethodInfo>();

            foreach (MethodInfo i in Type.GetType("Conductor.Orcamentacao.Web.Controllers." + classe).GetMethods().Where(m=> m.IsSpecialName==false).ToList())
            
                   retorno.Add(i);

            return retorno;
        }
    }
}