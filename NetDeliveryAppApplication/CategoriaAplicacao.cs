using AutoMapper;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<CategoriaDTO> Listar()
        {
            return _mapper.Map<List<CategoriaDTO>>(_categoriaRepository.Listar());
        }
        public CategoriaDTO Encontrar(int id)
        {
            if (_categoriaRepository.Existe(id))
            {
                return _mapper.Map<CategoriaDTO>(_categoriaRepository.Encontrar(id));
            }
            else
                throw new Exception("Categoria não existe.");
        }

        public void Editar(CategoriaDTO categoriaDTO)
        {
            if (_categoriaRepository.Existe(categoriaDTO.Id))
            {
                _categoriaRepository.Editar(_mapper.Map<Categoria>(categoriaDTO));
                _categoriaRepository.Salvar();
            }
            else
                throw new Exception("Categoria não existe.");
        }

        public void Adicionar(CategoriaDTO categoriaDTO)
        {
            _categoriaRepository.Adicionar(_mapper.Map<Categoria>(categoriaDTO));
            _categoriaRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_categoriaRepository.Existe(id))
            {
                var categoriaDTO = _mapper.Map<Categoria>(_categoriaRepository.Encontrar(id));

                _categoriaRepository.Deletar(categoriaDTO);
                _categoriaRepository.Salvar();
            }
            else
                throw new Exception("Categoria não existe.");
        }
    }
}
