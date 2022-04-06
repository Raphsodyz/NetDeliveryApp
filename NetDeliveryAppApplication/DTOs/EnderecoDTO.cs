using NetDeliveryAppDominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.DTOs
{
    public class EnderecoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Rua' não pode estar vazio.")]
        [Display(Name = "Rua")]
        [StringLength(70, ErrorMessage = "Digite uma rua válida.", MinimumLength = 2)]
        public string Rua { get; set; } = null!;

        [Required(ErrorMessage = "O campo 'Número' não pode estar vazio.")]
        [Display(Name = "Número")]
        [Range(1, 99999)]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo 'Bairro' não pode estar vazio.")]
        [Display(Name = "Bairro")]
        [StringLength(50, ErrorMessage = "Digite um bairro válido.", MinimumLength = 2)]
        public string Bairro { get; set; } = null!;

        [Display(Name = "Cidade")]
        [StringLength(50, ErrorMessage = "Digite uma cidade válida.", MinimumLength = 2)]
        public string? Cidade { get; set; }

        [Display(Name = "Observação")]
        [StringLength(2000, ErrorMessage = "Digite uma observação válida.", MinimumLength = 2)]
        public string? Observacao { get; set; }

        [Display(Name = "Cliente")]
        public virtual int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; } = null!;
    }
}
