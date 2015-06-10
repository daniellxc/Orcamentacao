using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.DTO
{
    [Table("ProjetoRequisito")]
     public class ProjetoRequisitoDTO
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRequisito { get; set; }

        [Required(ErrorMessage="Informe um identificador para o requisito")]
        public string IdInterno { get; set; }

        [Required(ErrorMessage = "Informe uma descrição para o requisito")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Um requisito deve estar vinculado a um projeto")]
        public int IdProjeto{ get; set; }

        #region ForeignKeys

        [ForeignKey("IdProjeto")]
        public virtual ProjetoDTO FK_Projeto { get; set; }

        #endregion

        public ProjetoRequisitoDTO()
        {

        }
    }
}
