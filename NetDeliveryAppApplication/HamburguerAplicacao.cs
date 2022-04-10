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
    public class HamburguerAplicacao : IHamburguerAplicacao
    {
        private readonly IHamburguerRepository _hamburguerRepository;
        private readonly IMapper _mapper;
        public HamburguerAplicacao(IHamburguerRepository hamburguerRepository, IMapper mapper)
        {
            _hamburguerRepository = hamburguerRepository;
            _mapper = mapper;
        }

        public List<HamburguerDTO> Listar()
        {
            return _mapper.Map<List<HamburguerDTO>>(_hamburguerRepository.Listar());
        }
        public HamburguerDTO Encontrar(int id)
        {
            if (_hamburguerRepository.Existe(id))
            {
                return _mapper.Map<HamburguerDTO>(_hamburguerRepository.Encontrar(id));
            }
            else
                throw new Exception("Hamburguer não existe.");
        }

        public void Editar(HamburguerDTO hamburguerDTO)
        {
            if (_hamburguerRepository.Existe(hamburguerDTO.Id))
            {
                _hamburguerRepository.Editar(_mapper.Map<Hamburguer>(hamburguerDTO));
                _hamburguerRepository.Salvar();
            }
            else
                throw new Exception("Hamburguer não existe.");
        }

        public void Adicionar(HamburguerDTO hamburguerDTO)
        {
            _hamburguerRepository.Adicionar(_mapper.Map<Hamburguer>(hamburguerDTO));
            _hamburguerRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_hamburguerRepository.Existe(id))
            {
                var hamburguerDTO = _mapper.Map<Hamburguer>(_hamburguerRepository.Encontrar(id));

                _hamburguerRepository.Deletar(hamburguerDTO);
                _hamburguerRepository.Salvar();
            }
            else
                throw new Exception("Hamburguer não existe.");
        }
    }
}
