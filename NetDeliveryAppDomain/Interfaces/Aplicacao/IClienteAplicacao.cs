using NetDeliveryAppDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Interfaces.Aplicacao
{
    public interface IClienteAplicacao
    {
        List<Cliente> Listar();
        Cliente Encontrar(int id);
        void Editar(Cliente cliente);
        void Adicionar(Cliente cliente);
        void Deletar(int id);
    }
}
