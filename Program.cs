using Gestor_de_Estoque_Orientado_à_obj;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque_Orientado_à_obj
{
    class Program

    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saída, Sair }

        enum CadastroProd { ProdutoFisico = 1, Ebook, Curso }
        static void Main(string[] args)
        {
            Carregar();
            bool escolheusair = false;


            while (!escolheusair)
            {
                Console.WriteLine("Sistema de Estoque");
                Console.WriteLine();
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar Entrada\n5-Registrar Saída\n6-Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                Menu escolha = (Menu)opInt;

                if (opInt > 0 && opInt < 7)
                {
                    switch (escolha)

                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saída:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheusair = true;
                            break;


                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida, o programa será encerrado");
                    Console.ReadLine();
                    escolheusair = true;
                }

                Console.Clear();




            }
        }


        static void Listagem()
        {
            Console.WriteLine("Lista de Produtos");
            int i = 0;
            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Escolha o ID do elemento que deseja dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Escolha o ID do elemento que deseja dar baixa: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Escolha o ID do elemento que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Console.WriteLine("Produto removido!");
                Console.ReadLine();
                Salvar();
            }
        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produtos");
            Console.WriteLine("1-Produto Físico\n2-Ebook\n3-Curso");
            string OpiStr = Console.ReadLine();
            int OpiInt = int.Parse(OpiStr);
            CadastroProd tipo =(CadastroProd)OpiInt;

            switch (tipo)
            {
                case CadastroProd.ProdutoFisico:
                    CadastrarPfisico();
                    break;
                case CadastroProd.Ebook:
                    CadastrarEbook();
                    break;
                case CadastroProd.Curso:
                    CadastrarCurso();
                    break;
            }
    
        }
        static void CadastrarPfisico()
        {
            Console.WriteLine("Cadastrando Produto Físico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();


            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();

        }

        static void Salvar()
        {
            FileStream stream = new FileStream("products.dat",FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();



        }
        static void Carregar()
        {
            FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);
                if (produtos == null) 
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch (Exception e) 
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
        }
    }
}
