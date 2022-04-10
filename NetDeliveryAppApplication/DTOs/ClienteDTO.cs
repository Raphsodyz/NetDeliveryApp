using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.DTOs
{
    public class ClienteDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' não pode estar vazio.")]
        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "Digite um nome válido.", MinimumLength = 2)]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O campo 'CPF' não pode estar vazio.")]
        [Display(Name = "CPF")]
        [StringLength(20, ErrorMessage = "Digite um CPF válido.", MinimumLength = 11)]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor, digite somente números.")]
        public string Cpf { get; set; } = null!;

        [Required(ErrorMessage = "O campo 'Telefone' não pode estar vazio.")]
        [Phone(ErrorMessage = "O campo deve estar no formato de telefone")]
        [Display(Name = "Telefone")]
        [StringLength(25, ErrorMessage = "Digite um telefone válido.", MinimumLength = 10)]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor, digite somente números.")]
        public string Telefone { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime? DataCriacao { get; set; }

        [Display(Name = "Foto")]
        [DataType(DataType.ImageUrl)]
        [StringLength(5000, ErrorMessage = "Digite uma link válido.", MinimumLength = 2)]
        public string? Foto { get; set; } = null!;
    }
}
