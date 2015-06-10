using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.DTO
{
    [Table("Projeto")]
    public class ProjetoDTO
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProjeto { get; set; }

        [Required(ErrorMessage="Informe o ID do projeto")]
        public string IdInterno{ get; set; }

        [Required(ErrorMessage = "Informe o nome do projeto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O projeto deve estar vinculado a um recurso")]
        public int IdRecurso { get; set; }


        public bool Ativo { get; set; }

        #region ForeignKeys

        [ForeignKey("IdRecurso")]
        public virtual RecursoDTO FK_Recurso { get; set; }

        #endregion
        public ProjetoDTO()
        {
                
        }
    }
}
