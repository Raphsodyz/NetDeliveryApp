using NetDeliveryAppDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Interfaces.Aplicacao
{
    public interface IHamburguerAplicacao
    {
        List<Hamburguer> Listar();
        Hamburguer Encontrar(int id);
        void Editar(Hamburguer hamburguer);
        void Adicionar(Hamburguer hamburguer);
        void Deletar(int id);
    }
}
