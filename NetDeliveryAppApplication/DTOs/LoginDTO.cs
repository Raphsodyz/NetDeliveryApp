using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo não pode estar vazio.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        [Display(Name = "E-mail")]
        [StringLength(70, ErrorMessage = "Digite um e-mail válido.", MinimumLength = 8)]
        [ProtectedPersonalData]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo não pode estar vazio.")]
        [StringLength(100, ErrorMessage = "O {0} precisater ao menos {2} e o máximo de {1} tamanho.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [ProtectedPersonalData]
        public string PasswordHash { get; set; }

    }
}
