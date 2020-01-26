using ExemploADONETCurso.BLL;
using ExemploADONETCurso.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploADONETCurso
{
    class Program
    {
        static ClienteBLL bll = new ClienteBLL();

        static void Main(string[] args)
        {
            int opcao = 0;
            do
            {
                MostrarMenu();
                Console.WriteLine("Digite a opção desejada: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch(opcao)
                {
                    case 1:
                        Inserir();
                        break;
                    case 2:
                        Atualizar();
                        break;
                    case 3:
                        Excluir();
                        break;
                    case 4:
                        ImprimirTodos();
                        break;
                    case 5:
                        ImprimirPorId();
                        break;
                }

            } while (opcao > 0);

            Console.ReadKey();
        }

        static void ImprimirPorId()
        {
            Cliente c = BuscarClienteDigitacao();

            MostrarClienteFormatado(c);
        }

        static void ImprimirTodos()
        {
            foreach (var item in bll.Buscar())
            {
                MostrarClienteFormatado(item);
            }
        }

        static void Inserir()
        {
            Cliente c = new Cliente();
            Console.WriteLine("Digite o Nome do cliente:");
            c.Nome = Console.ReadLine();
            Console.WriteLine("Digite a Data de Nascimento do cliente (dd/mm/yyyy):");
            c.DataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            bll.Inserir(c);
            Console.WriteLine("Cliente inserido com sucesso!");
        }

        static void Atualizar()
        {
            MostrarListaClientes();
            Cliente c = BuscarClienteDigitacao();
            Console.WriteLine("Digite o Nome do cliente:");
            c.Nome = Console.ReadLine();
            Console.WriteLine("Digite a Data de Nascimento do cliente (dd/mm/yyyy):");
            c.DataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            bll.Atualizar(c);
            Console.WriteLine("Cliente atualizado com sucesso!");
        }

        static void Excluir()
        {
            MostrarListaClientes();
            Cliente c = BuscarClienteDigitacao();

            bll.Excluir(c);
            Console.WriteLine("Cliente excluído com sucesso!");
        }

        static void MostrarClienteFormatado(Cliente c)
        {
            Console.WriteLine($"ID: {c.Id}");
            Console.WriteLine($"Nome: {c.Nome}");
            Console.WriteLine($"Data de Nascimento: {c.DataNascimento}");
        }

        static void MostrarMenu()
        {
            Console.WriteLine("1 - Inserir Cliente");
            Console.WriteLine("2 - Atualizar Cliente");
            Console.WriteLine("3 - Excluir Cliente");
            Console.WriteLine("4 - Buscar todos os clientes");
            Console.WriteLine("5 - Buscar cliente por ID");
            Console.WriteLine("0 - Sair");
        }

        static void MostrarListaClientes()
        {
            foreach (var item in bll.Buscar())
            {
                Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome}");
            }
        }

        static Cliente BuscarClienteDigitacao()
        {
            Console.WriteLine("Digite o Id do Cliente: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Cliente c = bll.Buscar(id);

            return c;
        }
    }
}
