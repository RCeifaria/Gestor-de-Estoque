using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque_Orientado_à_obj
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Registrar quandtidade adicionada ao estoque do produto {nome} ");
            Console.WriteLine("Digite a quantidade que deseja dar entrada: ");
            int entrada = int.Parse( Console.ReadLine() );
            estoque += entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Registrar quandtidade de saída no estoque do produto {nome} ");
            Console.WriteLine("Digite a quantidade que deseja dar baixa do estoque: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque -= entrada;
            Console.WriteLine("Saída Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Quantida estoque: {estoque}");
            Console.WriteLine("================");
        }
    }
}
