using Restaurante;

namespace Restaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pedidos pedidosDia = new Pedidos();
            int opcao;
            do
            {
                Console.WriteLine("\n--- Restaurante ---");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Criar novo pedido");
                Console.WriteLine("2. Adicionar item ao pedido");
                Console.WriteLine("3. Remover item do pedido");
                Console.WriteLine("4. Consultar pedido");
                Console.WriteLine("5. Cancelar pedido");
                Console.WriteLine("6. Listar todos os pedidos");
                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Id do pedido: ");
                        int idPedido = int.Parse(Console.ReadLine());
                        Console.Write("Nome do cliente: ");
                        string cliente = Console.ReadLine();
                        Pedido novo = new Pedido(idPedido, cliente);
                        Console.WriteLine(pedidosDia.adicionar(novo) ? "Pedido criado." : "Erro ao criar pedido.");
                        break;

                    case 2:
                        Console.Write("Id do pedido: ");
                        int idAdd = int.Parse(Console.ReadLine());
                        Pedido pedAdd = pedidosDia.pesquisar(new Pedido(idAdd));
                        if (pedAdd.Id != -1)
                        {
                            Console.Write("Id do item: ");
                            int idItem = int.Parse(Console.ReadLine());
                            Console.Write("Descrição: ");
                            string desc = Console.ReadLine();
                            Console.Write("Preço: ");
                            double preco = double.Parse(Console.ReadLine());
                            Console.WriteLine(pedAdd.adicionarItem(new Item(idItem, desc, preco)) ? "Item adicionado." : "Erro.");
                        }
                        else Console.WriteLine("Pedido não encontrado.");
                        break;

                    case 3:
                        Console.Write("Id do pedido: ");
                        int idRem = int.Parse(Console.ReadLine());
                        Pedido pedRem = pedidosDia.pesquisar(new Pedido(idRem));
                        if (pedRem.Id != -1)
                        {
                            Console.Write("Id do item: ");
                            int idItem = int.Parse(Console.ReadLine());
                            Console.WriteLine(pedRem.removerItem(new Item(idItem)) ? "Item removido." : "Item não encontrado.");
                        }
                        else Console.WriteLine("Pedido não encontrado.");
                        break;

                    case 4:
                        Console.Write("Id do pedido: ");
                        int idCons = int.Parse(Console.ReadLine());
                        Pedido pedCons = pedidosDia.pesquisar(new Pedido(idCons));
                        if (pedCons.Id != -1)
                        {
                            Console.WriteLine(pedCons.ToString());
                            Console.WriteLine("Itens:");
                            Console.WriteLine(pedCons.mostrarItens());
                        }
                        else Console.WriteLine("Pedido não encontrado.");
                        break;

                    case 5:
                        Console.Write("Id do pedido: ");
                        int idCanc = int.Parse(Console.ReadLine());
                        Console.WriteLine(pedidosDia.remover(new Pedido(idCanc)) ? "Pedido cancelado." : "Não encontrado.");
                        break;

                    case 6:
                        Console.WriteLine(pedidosDia.mostrar());
                        break;
                }
            } while (opcao != 0);
        }
    }
}
