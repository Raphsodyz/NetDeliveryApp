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
    public class HamburguerAplicacao : IHamburguerAplicacao
    {
        private readonly IHamburguerRepository _hamburguerRepository;
        public HamburguerAplicacao(IHamburguerRepository hamburguerRepository)
        {
            _hamburguerRepository = hamburguerRepository;
        }

        public List<Hamburguer> Listar()
        {
            return _hamburguerRepository.Listar();
        }
        public Hamburguer Encontrar(int id)
        {
            if (_hamburguerRepository.Existe(id))
            {
                return _hamburguerRepository.Encontrar(id);
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Editar(Hamburguer hamburguer)
        {
            if (_hamburguerRepository.Existe(hamburguer.Id))
            {
                _hamburguerRepository.Editar(hamburguer);
                _hamburguerRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Adicionar(Hamburguer hamburguer)
        {
            _hamburguerRepository.Adicionar(hamburguer);
            _hamburguerRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_hamburguerRepository.Existe(id))
            {
                var hamburguer = _hamburguerRepository.Encontrar(id);

                _hamburguerRepository.Deletar(hamburguer);
                _hamburguerRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }
    }
}
