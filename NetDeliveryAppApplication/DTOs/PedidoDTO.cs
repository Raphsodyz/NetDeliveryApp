using NetDeliveryAppDominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.DTOs
{
    public class PedidoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Valor' não pode estar vazio.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        [Range(0, double.MaxValue, ErrorMessage = "Por favor, digite somente números.")]
        public decimal Valor { get; set; }

        [Display(Name = "Observação")]
        [StringLength(2000, ErrorMessage = "Digite uma observação válida.", MinimumLength = 2)]
        public string? Observacao { get; set; }

        [Display(Name = "Horário do pedido")]
        [DataType(DataType.DateTime)]
        public DateTime DataPedido { get; set; }

        [Required(ErrorMessage = "O campo 'Itens' não pode estar vazio.")]
        [Display(Name = "Itens")]
        [StringLength(3000, ErrorMessage = "O item não é válido.", MinimumLength = 2)]
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
        [Range(typeof(bool), "true", "true", ErrorMessage = "O campo deve estar selecionado.")]
        public bool Entregue { get; set; }

        [Display(Name = "Cliente")]
        public virtual int ClienteId { get; set; }
        public virtual ClienteDTO? Cliente { get; set; } = null!;
    }
}
