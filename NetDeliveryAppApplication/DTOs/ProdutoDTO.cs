using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.DTOs
{
    public class ProdutoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' não pode estar vazio.")]
        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "Digite um nome válido.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Display(Name = "Ingredientes")]
        [StringLength(200, ErrorMessage = "Digite todos os ingredientes.", MinimumLength = 2)]
        public string? Ingredientes { get; set; }

        [Required(ErrorMessage = "O campo 'Valor' não pode estar vazio.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        [Range(0, double.MaxValue, ErrorMessage = "Por favor, digite somente números.")]
        public decimal Valor { get; set; }

        [Display(Name = "Sabor")]
        [StringLength(20, ErrorMessage = "Digite um sabor válido.", MinimumLength = 2)]
        public string? Sabor { get; set; }

        [Display(Name = "Volume")]
        [StringLength(50, ErrorMessage = "Digite um volume válido.", MinimumLength = 2)]
        public string? Volume { get; set; }

        [Display(Name = "Foto")]
        [DataType(DataType.ImageUrl)]
        [StringLength(5000, ErrorMessage = "Digite uma link válido.", MinimumLength = 2)]
        public string? Foto { get; set; }

        [Display(Name = "Categoria")]
        public virtual int? CategoriaId { get; set; }
        public CategoriaDTO? Categoria { get; set; }
    }
}
