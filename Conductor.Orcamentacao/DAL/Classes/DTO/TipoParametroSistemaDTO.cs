using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.DTO
{
    [Table("TipoParametroSistema")]
    public class TipoParametroSistemaDTO
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoParametroSistema { get; set; }

        [Required(ErrorMessage="Informe o tipo de parâmetro")]
        public  string Nome { get; set; }

        public bool Ativo { get; set; }

        public TipoParametroSistemaDTO()
        {

        }
    }
}
