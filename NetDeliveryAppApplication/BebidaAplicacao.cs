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
    public class BebidaAplicacao : IBebidaAplicacao
    {
        private readonly IBebidaRepository _bebidaRepository;
        private readonly IMapper _mapper;
        public BebidaAplicacao(IBebidaRepository bebidaRepository, IMapper mapper)
        {
            _bebidaRepository = bebidaRepository;
            _mapper = mapper;
        }

        public List<BebidaDTO> Listar()
        {
            return _mapper.Map<List<BebidaDTO>>(_bebidaRepository.Listar());
        }
        public BebidaDTO Encontrar(int id)
        {
            if (_bebidaRepository.Existe(id))
            {
                return _mapper.Map<BebidaDTO>(_bebidaRepository.Encontrar(id));
            }
            else
                throw new Exception("Bebida não existe.");
        }

        public void Editar(BebidaDTO bebidaDTO)
        {
            if (_bebidaRepository.Existe(bebidaDTO.Id))
            {
                _bebidaRepository.Editar(_mapper.Map<Bebida>(bebidaDTO));
                _bebidaRepository.Salvar();
            }
            else
                throw new Exception("Bebida não existe.");
        }

        public void Adicionar(BebidaDTO bebidaDTO)
        {
            _bebidaRepository.Adicionar(_mapper.Map<Bebida>(bebidaDTO));
            _bebidaRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_bebidaRepository.Existe(id))
            {
                var bebidaDTO = _mapper.Map<Bebida>(_bebidaRepository.Encontrar(id));

                _bebidaRepository.Deletar(bebidaDTO);
                _bebidaRepository.Salvar();
            }
            else
                throw new Exception("Bebida não existe.");
        }
    }
}
