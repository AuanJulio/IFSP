using ProjGerenciamentoProjetos;

namespace ProjGerenciamentoProjetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Projetos sistema = new Projetos();
            int opcao;

            do
            {
                Console.WriteLine("\n==== GERENCIAMENTO DE PROJETOS ====");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar projeto");
                Console.WriteLine("2. Pesquisar projeto");
                Console.WriteLine("3. Remover projeto");
                Console.WriteLine("4. Adicionar tarefa em projeto");
                Console.WriteLine("5. Concluir tarefa");
                Console.WriteLine("6. Cancelar tarefa");
                Console.WriteLine("7. Reabrir tarefa");
                Console.WriteLine("8. Listar tarefas de um projeto");
                Console.WriteLine("9. Filtrar tarefas por status ou prioridade");
                Console.WriteLine("10. Resumo geral");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Id do projeto: ");
                        int idP = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine(sistema.adicionar(new Projeto(idP, nome)) ? "Adicionado!" : "Já existe.");
                        break;

                    case 2:
                        Console.Write("Id do projeto: ");
                        int idBusca = int.Parse(Console.ReadLine());
                        Projeto projBuscado = sistema.buscar(new Projeto(idBusca));
                        if (projBuscado.Id != -1)
                        {
                            Console.WriteLine(projBuscado);
                            Console.WriteLine($"Abertas: {projBuscado.totalAbertas()}, Fechadas: {projBuscado.totalFechadas()}, Canceladas: {projBuscado.totalCanceladas()}");
                        }
                        else Console.WriteLine("Projeto não encontrado.");
                        break;

                    case 3:
                        Console.Write("Id do projeto: ");
                        int idRem = int.Parse(Console.ReadLine());
                        Console.WriteLine(sistema.remover(new Projeto(idRem)) ? "Removido!" : "Não pôde ser removido.");
                        break;

                    case 4:
                        Console.Write("Id do projeto: ");
                        int idAdd = int.Parse(Console.ReadLine());
                        Projeto p = sistema.buscar(new Projeto(idAdd));
                        if (p.Id != -1)
                        {
                            Console.Write("Id da tarefa: ");
                            int idT = int.Parse(Console.ReadLine());
                            Console.Write("Título: ");
                            string tit = Console.ReadLine();
                            Console.Write("Descrição: ");
                            string desc = Console.ReadLine();
                            Console.Write("Prioridade (1=Alta,2=Média,3=Baixa): ");
                            int pri = int.Parse(Console.ReadLine());
                            Console.WriteLine(p.adicionarTarefa(new Tarefa(idT, tit, desc, pri)) ? "Tarefa adicionada!" : "Não foi possível.");
                        }
                        else Console.WriteLine("Projeto não encontrado.");
                        break;

                    case 5:
                    case 6:
                    case 7:
                        Console.Write("Id do projeto: ");
                        int idProj = int.Parse(Console.ReadLine());
                        Projeto pA = sistema.buscar(new Projeto(idProj));
                        if (pA.Id != -1)
                        {
                            Console.Write("Id da tarefa: ");
                            int idTarefa = int.Parse(Console.ReadLine());
                            Tarefa t = pA.buscarTarefa(new Tarefa(idTarefa));
                            if (t.Id != -1)
                            {
                                if (opcao == 5) t.concluir();
                                else if (opcao == 6) t.cancelar();
                                else t.reabrir();
                                Console.WriteLine("Operação realizada.");
                            }
                            else Console.WriteLine("Tarefa não encontrada.");
                        }
                        else Console.WriteLine("Projeto não encontrado.");
                        break;

                    case 8:
                        Console.Write("Id do projeto: ");
                        int idList = int.Parse(Console.ReadLine());
                        Projeto pL = sistema.buscar(new Projeto(idList));
                        if (pL.Id != -1)
                        {
                            foreach (Tarefa t in pL.Tarefas)
                                Console.WriteLine(t);
                        }
                        else Console.WriteLine("Projeto não encontrado.");
                        break;

                    case 9:
                        Console.Write("Id do projeto: ");
                        int idFil = int.Parse(Console.ReadLine());
                        Projeto pF = sistema.buscar(new Projeto(idFil));
                        if (pF.Id != -1)
                        {
                            Console.Write("Filtrar por (S)tatus ou (P)rioridade? ");
                            string tipo = Console.ReadLine().ToUpper();
                            if (tipo == "S")
                            {
                                Console.Write("Status: ");
                                string st = Console.ReadLine();
                                foreach (Tarefa t in pF.tarefasPorStatus(st))
                                    Console.WriteLine(t);
                            }
                            else
                            {
                                Console.Write("Prioridade (1,2,3): ");
                                int priF = int.Parse(Console.ReadLine());
                                foreach (Tarefa t in pF.tarefasPorPrioridade(priF))
                                    Console.WriteLine(t);
                            }
                        }
                        else Console.WriteLine("Projeto não encontrado.");
                        break;

                    case 10:
                        Console.WriteLine($"Projetos: {sistema.totalProjetos()}");
                        Console.WriteLine($"Tarefas Abertas: {sistema.totalTarefasAbertas()}");
                        Console.WriteLine($"Tarefas Fechadas: {sistema.totalTarefasFechadas()}");
                        Console.WriteLine($"Tarefas Canceladas: {sistema.totalTarefasCanceladas()}");
                        break;
                }

            } while (opcao != 0);
        }
    }
}