using Vendedores;

namespace Vendedores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vendedores vendedores = new Vendedores(10);
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Cadastrar vendedor");
                Console.WriteLine("2 - Consultar vendedor");
                Console.WriteLine("3 - Excluir vendedor");
                Console.WriteLine("4 - Registrar venda");
                Console.WriteLine("5 - Listar vendedores");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Perc. Comissão: ");
                        double perc = double.Parse(Console.ReadLine());
                        Vendedor v = new Vendedor(id, nome, perc);
                        Console.WriteLine(vendedores.addVendedor(v) ? "Cadastrado!" : "Limite atingido!");
                        break;

                    case 2:
                        Console.Write("Id: ");
                        int idBusca = int.Parse(Console.ReadLine());
                        Vendedor encontrado = vendedores.searchVendedor(idBusca);
                        if (encontrado == null)
                            Console.WriteLine("Não encontrado!");
                        else
                        {
                            Console.WriteLine($"ID: {encontrado.Id}, Nome: {encontrado.Nome}");
                            Console.WriteLine($"Vendas: {encontrado.valorVendas():C}");
                            Console.WriteLine($"Comissão: {encontrado.valorComissao():C}");
                        }
                        break;

                    case 3:
                        Console.Write("Id: ");
                        int idDel = int.Parse(Console.ReadLine());
                        Console.WriteLine(vendedores.delVendedor(idDel) ? "Excluído!" : "Não foi possível excluir.");
                        break;

                    case 4:
                        Console.Write("Id do vendedor: ");
                        int idVend = int.Parse(Console.ReadLine());
                        Vendedor v2 = vendedores.searchVendedor(idVend);
                        if (v2 == null) { Console.WriteLine("Vendedor não existe!"); break; }
                        Console.Write("Dia da venda (1-31): ");
                        int dia = int.Parse(Console.ReadLine());
                        Console.Write("Qtde vendida: ");
                        int qtde = int.Parse(Console.ReadLine());
                        Console.Write("Valor total: ");
                        double valor = double.Parse(Console.ReadLine());
                        v2.registrarVenda(dia, new Venda(qtde, valor));
                        Console.WriteLine("Venda registrada!");
                        break;

                    case 5:
                        Console.WriteLine(vendedores.listar());
                        break;
                }
            }
        }
    }
}