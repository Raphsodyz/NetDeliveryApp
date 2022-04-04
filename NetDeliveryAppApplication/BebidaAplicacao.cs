using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Aplicacao;
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
        public BebidaAplicacao(IBebidaRepository bebidaRepository)
        {
            _bebidaRepository = bebidaRepository;
        }

        public List<Bebida> Listar()
        {
            return _bebidaRepository.Listar();
        }
        public Bebida Encontrar(int id)
        {
            if (_bebidaRepository.Existe(id))
            {
                return _bebidaRepository.Encontrar(id);
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Editar(Bebida bebida)
        {
            if (_bebidaRepository.Existe(bebida.Id))
            {
                _bebidaRepository.Editar(bebida);
                _bebidaRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Adicionar(Bebida bebida)
        {
            _bebidaRepository.Adicionar(bebida);
            _bebidaRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_bebidaRepository.Existe(id))
            {
                var bebida = _bebidaRepository.Encontrar(id);

                _bebidaRepository.Deletar(bebida);
                _bebidaRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }
    }
}
