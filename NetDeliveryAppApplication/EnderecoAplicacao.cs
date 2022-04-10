using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Entidades;
using NetDeliveryAppDominio.Interfaces.Repositorios;


namespace NetDeliveryAppAplicacao
{
    public class EnderecoAplicacao : IEnderecoAplicacao
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoAplicacao(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public List<Endereco> Listar()
        {
            return _enderecoRepository.Listar();
        }
        public Endereco Encontrar(int id)
        {
            if (_enderecoRepository.Existe(id))
            {
                return _enderecoRepository.Encontrar(id);
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Editar(Endereco endereco)
        {
            if (_enderecoRepository.Existe(endereco.Id))
            {
                _enderecoRepository.Editar(endereco);
                _enderecoRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }

        public void Adicionar(Endereco endereco)
        {
            _enderecoRepository.Adicionar(endereco);
            _enderecoRepository.Salvar();
        }

        public void Deletar(int id)
        {
            if (_enderecoRepository.Existe(id))
            {
                var endereco = _enderecoRepository.Encontrar(id);

                _enderecoRepository.Deletar(endereco);
                _enderecoRepository.Salvar();
            }
            else
                throw new Exception("Cliente não existe.");
        }
    }
}
