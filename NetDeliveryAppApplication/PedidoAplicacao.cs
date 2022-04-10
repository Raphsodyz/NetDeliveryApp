using AutoMapper;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppAplicacao
{
    public class PedidoAplicacao : IPedidoAplicacao
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        public PedidoAplicacao(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public List<PedidoDTO> Listar()
        {
            return _mapper.Map<List<PedidoDTO>>(_pedidoRepository.Listar());
        }
        public PedidoDTO Encontrar(int id)
        {
            if (_pedidoRepository.Existe(id))
            {
                return _mapper.Map<PedidoDTO>(_pedidoRepository.Encontrar(id));
            }
            else
                throw new Exception("Pedido não existe.");
        }

        public void Editar(PedidoDTO pedidoDTO)
        {
            if (_pedidoRepository.Existe(pedidoDTO.Id))
            {
                _pedidoRepository.Editar(_mapper.Map<Pedido>(pedidoDTO));
                _pedidoRepository.Salvar();
            }
            else
                throw new Exception("Pedido não existe.");
        }

        public void Adicionar(PedidoDTO pedidoDTO)
        {
            _pedidoRepository.Adicionar(_mapper.Map<Pedido>(pedidoDTO));
            _pedidoRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_pedidoRepository.Existe(id))
            {
                var pedidoDTO = _mapper.Map<Pedido>(_pedidoRepository.Encontrar(id));

                _pedidoRepository.Deletar(pedidoDTO);
                _pedidoRepository.Salvar();
            }
            else
                throw new Exception("Pedido não existe.");
        }
    }
}
