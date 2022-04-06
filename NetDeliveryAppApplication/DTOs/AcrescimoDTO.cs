using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.DTOs
{
    public class AcrescimoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' não pode estar vazio.")]
        [Display(Name = "Nome do acréscimo")]
        [StringLength(50, ErrorMessage = "Digite um nome válido.", MinimumLength = 2)]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O campo 'Valor' não pode estar vazio.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
    }
}
