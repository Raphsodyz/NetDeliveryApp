using NetDeliveryAppDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Interfaces.Aplicacao
{
    public interface IPedidoAplicacao
    {
        List<Pedido> Listar();
        Pedido Encontrar(int id);
        void Editar(Pedido pedido);
        void Adicionar(Pedido pedido);
        void Deletar(int id);
    }
}
