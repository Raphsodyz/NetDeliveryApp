using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppAplicacao.Interfaces
{
    public interface IAplicacao<T> where T : class
    {
        Task<List<T>> Listar();
        Task<T> Encontrar(int id);
        Task Editar(T entidade);
        void Adicionar(T entidade);
        Task Deletar(int id);
        Task<bool> Salvar();
    }
}
