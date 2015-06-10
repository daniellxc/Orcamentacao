using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.DTO
{
    [Table("ProjetoAtividadePrioridade")]
    public class ProjetoAtividadePrioridadeDTO
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrioridadeAtividade { get; set; }

        [Required(ErrorMessage="Informe o nome da prioridade")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o peso da prioridade")]
        public int Peso { get; set; }

        public ProjetoAtividadePrioridadeDTO()
        {

        }
    }
}
