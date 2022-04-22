using AutoMapper;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppDominio.Identity.Usuarios;
using NetDeliveryAppDominio.Identity;

namespace NetDeliveryAppAplicacao.Mapper
{
    public class NetDeliveryAppMapper : Profile
    {
        public NetDeliveryAppMapper()
        {
            CreateMap<AcrescimoDTO, Acrescimo>().ReverseMap();
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
            CreateMap<EnderecoDTO, Endereco>().ReverseMap();
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
            CreateMap<PedidoDTO, Pedido>().ReverseMap();
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
            CreateMap<LoginDTO, Usuario>().ReverseMap();
            CreateMap<ResetarSenhaDTO, ResetarSenha>().ReverseMap();
        }
    }
}
