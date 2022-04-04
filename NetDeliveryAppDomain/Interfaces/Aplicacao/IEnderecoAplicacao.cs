using NetDeliveryAppDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Interfaces.Aplicacao
{
    public interface IEnderecoAplicacao
    {
        List<Endereco> Listar();
        Endereco Encontrar(int id);
        void Editar(Endereco endereco);
        void Adicionar(Endereco endereco);
        void Deletar(int id);
    }
}
