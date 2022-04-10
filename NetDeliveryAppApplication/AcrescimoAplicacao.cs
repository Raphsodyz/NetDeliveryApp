using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;

namespace NetDeliveryAppAplicacao
{
    public class AcrescimoAplicacao : IAcrescimoAplicacao
    {
        private readonly IAcrescimoRepository _acrescimoRepository;
        public AcrescimoAplicacao(IAcrescimoRepository acrescimoRepository)
        {
            _acrescimoRepository = acrescimoRepository;
        }

        public List<Acrescimo> Listar()
        {
            return _acrescimoRepository.Listar();
        }
        public Acrescimo Encontrar(int id)
        {
            if (_acrescimoRepository.Existe(id))
            {
                return _acrescimoRepository.Encontrar(id);
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Editar(Acrescimo acrescimo)
        {
            if (_acrescimoRepository.Existe(acrescimo.Id))
            {
                _acrescimoRepository.Editar(acrescimo);
                _acrescimoRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Adicionar(Acrescimo acrescimo)
        {
            _acrescimoRepository.Adicionar(acrescimo);
            _acrescimoRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_acrescimoRepository.Existe(id))
            {
                var acrescimo = _acrescimoRepository.Encontrar(id);

                _acrescimoRepository.Deletar(acrescimo);
                _acrescimoRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }
    }
}
