using AutoMapper;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppAplicacao
{
    public class CategoriaAplicacao : ICategoriaAplicacao
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaAplicacao(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoriaDTO>> Listar()
        {
            return _mapper.Map<List<CategoriaDTO>>(await _categoriaRepository.Listar());
        }
        public async Task<CategoriaDTO> Encontrar(int id)
        {
            if (_categoriaRepository.Existe(id))
            {
                return _mapper.Map<CategoriaDTO>(await _categoriaRepository.Encontrar(id));
            }
            else
                throw new Exception("Categoria não existe.");
        }

        public async Task Editar(CategoriaDTO categoriaDTO)
        {
            var categoria = await _categoriaRepository.Achar(categoriaDTO.Id);
            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada.");
            }
            else
                _categoriaRepository.Editar(_mapper.Map<Categoria>(categoriaDTO));
        }

        public async Task<bool> Salvar()
        {
            return await _categoriaRepository.Salvar();
        }

        public void Adicionar(CategoriaDTO categoriaDTO)
        {
            _categoriaRepository.Adicionar(_mapper.Map<Categoria>(categoriaDTO));
        }

        public async Task Deletar(int id)
        {
            var categoria = await _categoriaRepository.Achar(id);
            if (categoria == null)
            {
                throw new Exception("Produto não existe.");
            }
            else
            {
                var categoriaDTO = _mapper.Map<ProdutoDTO>(categoria);
                _categoriaRepository.Deletar(categoriaDTO.Id);
            }
        }
    }
}
