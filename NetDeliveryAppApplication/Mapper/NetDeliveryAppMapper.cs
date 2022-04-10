using AutoMapper;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppAplicacao.DTOs;

namespace NetDeliveryAppAplicacao.Mapper
{
    public class NetDeliveryAppMapper : Profile
    {
        public NetDeliveryAppMapper()
        {
            CreateMap<AcrescimoDTO, Acrescimo>().ReverseMap();
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<EnderecoDTO, Endereco>().ReverseMap();
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
            CreateMap<PedidoDTO, Pedido>().ReverseMap();
        }
    }
}
