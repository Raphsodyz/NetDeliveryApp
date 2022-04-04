using NetDeliveryAppDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDeliveryAppDominio.Interfaces.Aplicacao
{
    public interface IAcrescimoAplicacao
    {
        List<Acrescimo> Listar();
        Acrescimo Encontrar(int id);
        void Editar(Acrescimo acrescimo);
        void Adicionar(Acrescimo acrescimo);
        void Deletar(int id);
    }
}
