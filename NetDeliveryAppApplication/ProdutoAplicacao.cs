using AutoMapper;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppAplicacao
{
    public class ProdutoAplicacao : IProdutoAplicacao
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoAplicacao(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProdutoDTO>> Listar()
        {
            return _mapper.Map<List<ProdutoDTO>>(await _produtoRepository.Listar());
        }
        public async Task<ProdutoDTO> Encontrar(int id)
        {
            if (_produtoRepository.Existe(id))
            {
                return _mapper.Map<ProdutoDTO>(await _produtoRepository.Encontrar(id));
            }
            else
                throw new Exception("Produto não existe.");
        }
        public async Task Editar(ProdutoDTO produtoDTO)
        {
            var produto = await _produtoRepository.Achar(produtoDTO.Id);
            if(!_produtoRepository.Existe(produto.Id))
            {
                throw new Exception("Produto não encontrado.");
            }
            else
                _produtoRepository.Editar(_mapper.Map<Produto>(produtoDTO));
        }

        public async Task<bool> Salvar()
        {
            return await _produtoRepository.Salvar();
        }

        public void Adicionar(ProdutoDTO produtoDTO)
        {
            _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoDTO));
        }

        public async Task Deletar(int id)
        {
            var produto = await _produtoRepository.Achar(id);
            if (produto == null)
            {
                throw new Exception("Produto não existe.");
            }
            else
            {
                var produtoDTO = _mapper.Map<ProdutoDTO>(produto);
                _produtoRepository.Deletar(produtoDTO.Id);
            }
        }
    }
}
