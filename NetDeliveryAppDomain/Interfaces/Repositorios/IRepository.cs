namespace NetDeliveryAppDominio.Interfaces.Repositorios
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> Listar();
        Task<T> Encontrar(int id);
        void Adicionar(T entidade);
        void Editar(T entidade);
        void Deletar(int id);
        Task<bool> Salvar();
        bool Existe(int id);
        Task<T> Achar(int id);
    }
}
