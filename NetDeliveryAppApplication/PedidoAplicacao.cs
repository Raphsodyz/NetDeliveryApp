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

        public async Task<List<PedidoDTO>> Listar()
        {
            return _mapper.Map<List<PedidoDTO>>(await _pedidoRepository.Listar());
        }
        public async Task<PedidoDTO> Encontrar(int id)
        {
            if (_pedidoRepository.Existe(id))
            {
                return _mapper.Map<PedidoDTO>(await _pedidoRepository.Encontrar(id));
            }
            else
                throw new Exception("Pedido não existe.");
        }

        public async Task Editar(PedidoDTO pedidoDTO)
        {
            var pedido = await _pedidoRepository.Achar(pedidoDTO.Id);
            if (pedido == null)
            {
                throw new Exception("Produto não encontrado.");
            }
            else
                _pedidoRepository.Editar(_mapper.Map<Pedido>(pedidoDTO));
        }

        public async Task<bool> Salvar()
        {
            return await _pedidoRepository.Salvar();
        }

        public void Adicionar(PedidoDTO pedidoDTO)
        {
            _pedidoRepository.Adicionar(_mapper.Map<Pedido>(pedidoDTO));
        }

        public async Task Deletar(int id)
        {
            var pedido = await _pedidoRepository.Achar(id);
            if (pedido == null)
            {
                throw new Exception("Produto não existe.");
            }
            else
            {
                var pedidoDTO = _mapper.Map<ProdutoDTO>(pedido);
                _pedidoRepository.Deletar(pedidoDTO.Id);
            }
        }
    }
}
