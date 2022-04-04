using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Interfaces.Aplicacao
{
    public interface IAplicacao<T> where T : class
    {
        List<T> Listar();
        T Encontrar(int id);
        void Editar(T entidade);
        void Adicionar(T entidade);
        void Deletar(int id);
    }
}
