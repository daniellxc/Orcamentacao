using DAL.Classes.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class Context:DbContext
    {
        #region construtores
        public Context():base("Conex")
        {

        }

        public Context(string connectionString):base(connectionString)
        {

        }
        #endregion


        
        #region dbsets 
        public DbSet<ParametroSistemaDTO> ParametrosSistema { get; set; }
        public DbSet<ProjetoDTO> Projetos { get; set; }
        public DbSet<ProjetoAtividadeDTO> Atividades { get; set; }
        public DbSet<ProjetoAtividadePrioridadeDTO> Prioridades { get; set; }
        public DbSet<ProjetoAtividadeRiscoDTO> Riscos { get; set; }
        public DbSet<RecursoDTO> Recursos { get; set; }
        public DbSet<TipoParametroSistemaDTO> TiposParametrosSistema { get; set; }

        #endregion
    }
}
