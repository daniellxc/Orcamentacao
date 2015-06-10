using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes.DTO
{
    [Table("ParametroSistema")]
    public class ParametroSistemaDTO
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdParametroSistema { get; set; }

        [MaxLength(100,ErrorMessage="O nome da classe deve possuir no máximo 100 caracteres!")]
        public string Classe { get; set; }

         [MaxLength(100, ErrorMessage = "O nome do método deve possuir no máximo 100 caracteres!")]
        public string Metodo { get; set; }

         public string Nome { get; set; }

        [Required]
         public string Valor { get; set; }

        [Required(ErrorMessage="Informe o tipo de parâmetro")]
        public int IdTipoParametroSistema { get; set; }

        public bool Ativo { get; set; }

        #region ForeignKey

        [ForeignKey("IdTipoParametroSistema")]
        public virtual TipoParametroSistemaDTO  FK_TipoParametroSistema{ get; set; }

        #endregion


        public ParametroSistemaDTO()
        {

        }


    }
}
