using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NetDeliveryAppAplicacao.DTOs.IdentityDTO;

public class UsuarioDTO
{
    [Required(ErrorMessage = "O campo 'Nome' não pode estar vazio.")]
    [Display(Name = "Nome")]
    [StringLength(250, ErrorMessage = "Digite um nome válido.", MinimumLength = 2)]
    [ProtectedPersonalData]
    public string UserName { get; set; }

    [ProtectedPersonalData]
    [Required(ErrorMessage = "O campo 'Telefone' não pode estar vazio.")]
    [Phone(ErrorMessage = "O campo deve estar no formato de telefone")]
    [Display(Name = "Telefone")]
    [StringLength(70, ErrorMessage = "Digite um telefone válido.", MinimumLength = 8)]
    [DataType(DataType.PhoneNumber)]
    public virtual string PhoneNumber { get; set; }

    [ProtectedPersonalData]
    [Required(ErrorMessage = "O campo não pode estar vazio.")]
    [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
    [Display(Name = "E-mail")]
    [StringLength(70, ErrorMessage = "Digite um nome válido.", MinimumLength = 8)]
    public string Email { get; set; }

    [ProtectedPersonalData]
    [Required(ErrorMessage = "O campo não pode estar vazio.")]
    [StringLength(100, ErrorMessage = "O {0} precisater ao menos {2} e o máximo de {1} tamanho.", MinimumLength = 4)]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string PasswordHash { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirme sua senha")]
    [Compare("PasswordHash", ErrorMessage = "As senhas são diferentes.")]
    public string ConfirmarSenha { get; set; }

    [Display(Name = "Foto")]
    [DataType(DataType.ImageUrl)]
    [StringLength(5000, ErrorMessage = "Digite uma link válido.", MinimumLength = 2)]
    public string? Foto { get; set; }
    [Required(ErrorMessage = "O campo endereço não pode estar vazio.")]
    [Range(0, int.MaxValue)]
    public int? EnderecoId { get; set; }
    [JsonIgnore]
    public EnderecoDTO Endereco { get; set; }
}
