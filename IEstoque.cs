using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque_Orientado_à_obj
{
    internal interface IEstoque
    { 
        void Exibir();
        void AdicionarEntrada();
        void AdicionarSaida();

    }
}
