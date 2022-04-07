using AutoMapper;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Mapper
{
    public class NetDeliveryAppMapper : Profile
    {
        public NetDeliveryAppMapper()
        {
            CreateMap<AcrescimoDTO, Acrescimo>().ReverseMap();
            CreateMap<BebidaDTO, Bebida>().ReverseMap();
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<EnderecoDTO, Endereco>().ReverseMap();
            CreateMap<HamburguerDTO, Hamburguer>().ReverseMap();
            CreateMap<PedidoDTO, Pedido>().ReverseMap();
        }
    }
}
