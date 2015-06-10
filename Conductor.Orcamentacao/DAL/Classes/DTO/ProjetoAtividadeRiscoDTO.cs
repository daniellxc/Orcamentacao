using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.DTO
{
    [Table("ProjetoAtividadeRisco")]
    public class ProjetoAtividadeRiscoDTO
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRiscoAtividade { get; set; }

        [Required(ErrorMessage="Identifique o risco")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descreva o risco")]
        public string Descricao { get; set; }
    }
}
