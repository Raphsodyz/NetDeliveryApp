using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Identity.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.DTOs
{
    public class PedidoDTO
    {
        [Key]
        [JsonIgnore]
        [Range(0, double.MaxValue, ErrorMessage = "Por favor, insira um valor válido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Valor' não pode estar vazio.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        [Range(0, double.MaxValue, ErrorMessage = "Por favor, insira um valor válido.")]
        [RegularExpression(@"-?\d+(?:\.\d+)?", ErrorMessage = "Por favor, digite somente números.")]
        public decimal Valor { get; set; }

        [Display(Name = "Observação")]
        [StringLength(2000, ErrorMessage = "Digite uma observação válida.", MinimumLength = 2)]
        public string? Observacao { get; set; }

        [Display(Name = "Horário do pedido")]
        [DataType(DataType.DateTime)]
        public DateTime DataPedido { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O campo 'Itens' não pode estar vazio.")]
        [Display(Name = "Itens")]
        [StringLength(3000, ErrorMessage = "O item não é válido.")]
        public string Itens { get; set; } = null!;

        [Required(ErrorMessage = "O campo 'Pagamento' não pode estar vazio.")]
        [Display(Name = "Pagamento")]
        [StringLength(70, ErrorMessage = "Selecione um meio de pagamento válido.", MinimumLength = 2)]
        public string Pagamento { get; set; } = null!;

        [Display(Name = "Troco")]
        [StringLength(70, ErrorMessage = "Digite seu troco.", MinimumLength = 2)]
        public string? Troco { get; set; } = null!;

        [Required(ErrorMessage = "O campo 'Entregue' não pode estar vazio.")]
        [Display(Name = "Entregue?")]
        public bool Entregue { get; set; }
        [Display(Name = "Categoria")]
        [Range(0, int.MaxValue)]
        [Required(ErrorMessage = "O campo usuário não pode estar vazio.")]
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario usuario { get; set; }
    }
}
