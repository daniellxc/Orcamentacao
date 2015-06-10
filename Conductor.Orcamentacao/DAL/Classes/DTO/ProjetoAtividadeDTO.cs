using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.DTO
{
    [Table("ProjetoRequisitoAtividade")]
    public class ProjetoAtividadeDTO
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAtividade { get; set; }

        [Required(ErrorMessage="Informe a descricao da atividade")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Proponha uma solução!")]
        public string Solucao { get; set; }

        [Required(ErrorMessage = "Informe o custo da atividade")]
        [Range(1,100,ErrorMessage="O menor custo permitido é 1")]
        public int Custo { get; set; }
       
        public string Observacao { get; set; }

        [Required(ErrorMessage = "A atividade deve estar vinculada a um requisito!")]
        public int IdRequisito { get; set; }

        [Required(ErrorMessage = "Informe o risco da atividade")]
        public int IdRisco { get; set; }

        [Required(ErrorMessage = "Informe a prioridade da atividade")]
        public int IdPrioridade { get; set; }

        #region ForeignKeys

        [ForeignKey("IdRequisito")]
        public virtual ProjetoRequisitoDTO FK_Requisito { get; set; }

        [ForeignKey("IdRisco")]
        public virtual ProjetoAtividadeRiscoDTO FK_Risco { get; set; }

        [ForeignKey("IdPrioridade")]
        public virtual ProjetoAtividadePrioridadeDTO FK_Prioridade { get; set; }



        #endregion

        public ProjetoAtividadeDTO()
        {

        }


    }
}
