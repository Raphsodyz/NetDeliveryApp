using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NetDeliveryAppAplicacao.DTOs
{
    public class AcrescimoDTO
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "ID inválido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' não pode estar vazio.")]
        [Display(Name = "Nome do acréscimo")]
        [StringLength(50, ErrorMessage = "Digite um nome válido.", MinimumLength = 2)]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O campo 'Valor' não pode estar vazio.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        [Range(0, double.MaxValue, ErrorMessage = "Por favor, digite número válido.")]
        [RegularExpression(@"-?\d+(?:\.\d+)?", ErrorMessage = "Por favor, digite somente números.")]
        public decimal Valor { get; set; }

        [Display(Name = "Categoria")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Insira um ID válido.")]
        public int? CategoriaId { get; set; }

        [JsonIgnore]
        public CategoriaDTO? Categoria { get; set; }
    }
}
