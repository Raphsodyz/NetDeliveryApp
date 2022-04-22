using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.DTOs
{
    public class ResetarSenhaDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo não pode estar vazio.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        [Display(Name = "E-mail")]
        [StringLength(70, ErrorMessage = "Digite um nome válido.", MinimumLength = 8)]
        [ProtectedPersonalData]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo não pode estar vazio.")]
        [Display(Name = "E-mail")]
        [StringLength(500, ErrorMessage = "Digite um nome válido.", MinimumLength = 5)]
        public string Token { get; set; }

        [Required(ErrorMessage = "O campo não pode estar vazio.")]
        [Display(Name = "Token")]
        [StringLength(500, ErrorMessage = "Digite um nome válido.", MinimumLength = 8)]
        public string OTP { get; set; }

        [Required(ErrorMessage = "O campo não pode estar vazio.")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
