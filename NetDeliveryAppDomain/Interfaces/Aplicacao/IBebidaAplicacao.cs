using NetDeliveryAppDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Interfaces.Aplicacao
{
    public interface IBebidaAplicacao
    {
        List<Bebida> Listar();
        Bebida Encontrar(int id);
        void Editar(Bebida bebida);
        void Adicionar(Bebida bebida);
        void Deletar(int id);
    }
}
