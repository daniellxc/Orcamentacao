using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.DTO
{
    [Table("Recurso")]
    public class RecursoDTO
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRecurso { get; set; }

        [Required(ErrorMessage="Informe o nome do recurso")]
        public string Nome { get; set; }

        public string Alias { get; set; }

        public bool Ativo { get; set; }

        public RecursoDTO()
        {

        }

    }
}
