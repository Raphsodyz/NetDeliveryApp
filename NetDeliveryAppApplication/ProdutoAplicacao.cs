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

        public List<ProdutoDTO> Listar()
        {
            return _mapper.Map<List<ProdutoDTO>>(_produtoRepository.Listar());
        }
        public ProdutoDTO Encontrar(int id)
        {
            if (_produtoRepository.Existe(id))
            {
                return _mapper.Map<ProdutoDTO>(_produtoRepository.Encontrar(id));
            }
            else
                throw new Exception("Produto não existe.");
        }

        public void Editar(ProdutoDTO produtoDTO)
        {
            if (_produtoRepository.Existe(produtoDTO.Id))
            {
                _produtoRepository.Editar(_mapper.Map<Produto>(produtoDTO));
                _produtoRepository.Salvar();
            }
            else
                throw new Exception("Produto não existe.");
        }

        public void Adicionar(ProdutoDTO produtoDTO)
        {
            _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoDTO));
            _produtoRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_produtoRepository.Existe(id))
            {
                var produtoDTO = _mapper.Map<Produto>(_produtoRepository.Encontrar(id));

                _produtoRepository.Deletar(produtoDTO);
                _produtoRepository.Salvar();
            }
            else
                throw new Exception("Produto não existe.");
        }
    }
}
