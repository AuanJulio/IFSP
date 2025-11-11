namespace ProjMedicamentos
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Medicamentos medicamentos = new Medicamentos();
            int opc = -1;

            while (opc != 0)
            {
                Console.WriteLine("\n===== MENU MEDICAMENTO =====");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos");
                Console.Write("\nOpção: ");
                opc = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opc)
                {
                    case 1:
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Laboratório: ");
                        string lab = Console.ReadLine();
                        medicamentos.Adicionar(new Medicamento(id, nome, lab));
                        Console.WriteLine("✅ Medicamento cadastrado!");
                        break;

                    case 2:
                        Console.Write("Informe o ID do medicamento: ");
                        int idPesq = int.Parse(Console.ReadLine());
                        Medicamento m1 = medicamentos.Pesquisar(new Medicamento(idPesq, "", ""));
                        if (m1.Id != -1)
                            Console.WriteLine(m1.ToString());
                        else
                            Console.WriteLine("❌ Medicamento não encontrado.");
                        break;

                    case 3:
                        Console.Write("Informe o ID do medicamento: ");
                        int idAnalit = int.Parse(Console.ReadLine());
                        Medicamento m2 = medicamentos.Pesquisar(new Medicamento(idAnalit, "", ""));
                        if (m2.Id != -1)
                        {
                            Console.WriteLine(m2.ToString());
                            foreach (Lote l in m2.Lotes)
                                Console.WriteLine("  -> " + l.ToString());
                        }
                        else
                            Console.WriteLine("❌ Medicamento não encontrado.");
                        break;

                    case 4:
                        Console.Write("ID do medicamento: ");
                        int idCompra = int.Parse(Console.ReadLine());
                        Medicamento m3 = medicamentos.Pesquisar(new Medicamento(idCompra, "", ""));
                        if (m3.Id != -1)
                        {
                            Console.Write("ID do lote: ");
                            int idLote = int.Parse(Console.ReadLine());
                            Console.Write("Quantidade: ");
                            int qtde = int.Parse(Console.ReadLine());
                            Console.Write("Data de vencimento (dd/mm/yyyy): ");
                            DateTime venc = DateTime.Parse(Console.ReadLine());
                            m3.Comprar(new Lote(idLote, qtde, venc));
                            Console.WriteLine("✅ Lote cadastrado com sucesso!");
                        }
                        else
                            Console.WriteLine("❌ Medicamento não encontrado.");
                        break;

                    case 5:
                        Console.Write("ID do medicamento: ");
                        int idVenda = int.Parse(Console.ReadLine());
                        Medicamento m4 = medicamentos.Pesquisar(new Medicamento(idVenda, "", ""));
                        if (m4.Id != -1)
                        {
                            Console.Write("Quantidade a vender: ");
                            int qtdeVenda = int.Parse(Console.ReadLine());
                            if (m4.Vender(qtdeVenda))
                                Console.WriteLine("✅ Venda realizada com sucesso!");
                            else
                                Console.WriteLine("❌ Quantidade insuficiente!");
                        }
                        else
                            Console.WriteLine("❌ Medicamento não encontrado.");
                        break;

                    case 6:
                        Console.WriteLine(medicamentos.ListarSintetico());
                        break;

                    case 0:
                        Console.WriteLine("Encerrando...");
                        break;

                    default:
                        Console.WriteLine("❌ Opção inválida!");
                        break;
                }
            }
        }
    }

    }