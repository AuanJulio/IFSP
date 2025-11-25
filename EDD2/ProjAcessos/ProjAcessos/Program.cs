using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAcessos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cadastro cad = new Cadastro();
            cad.download();

            int op = -1;

            while (op != 0)
            {
                Console.WriteLine("----------- MENU -----------");
                Console.WriteLine("1. Cadastrar ambiente");
                Console.WriteLine("2. Consultar ambiente");
                Console.WriteLine("3. Excluir ambiente");
                Console.WriteLine("4. Cadastrar usuário");
                Console.WriteLine("5. Consultar usuário");
                Console.WriteLine("6. Excluir usuário");
                Console.WriteLine("7. Conceder permissão");
                Console.WriteLine("8. Revogar permissão");
                Console.WriteLine("9. Registrar acesso");
                Console.WriteLine("10. Consultar logs");
                Console.WriteLine("0. Sair");
                Console.Write("Opção: ");

                op = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (op)
                {
                    case 1:
                        Console.Write("ID: ");
                        int idA = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nomeA = Console.ReadLine();
                        cad.adicionarAmbiente(new Ambiente(idA, nomeA));
                        break;

                    case 2:
                        Console.Write("ID: ");
                        Ambiente a = cad.pesquisarAmbiente(int.Parse(Console.ReadLine()));
                        Console.WriteLine(a != null ? a.ToString() : "Não encontrado.");
                        break;

                    case 3:
                        Console.Write("ID: ");
                        cad.removerAmbiente(new Ambiente(int.Parse(Console.ReadLine()), ""));
                        break;

                    case 4:
                        Console.Write("ID: ");
                        int idU = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nomeU = Console.ReadLine();
                        cad.adicionarUsuario(new Usuario(idU, nomeU));
                        break;

                    case 5:
                        Console.Write("ID: ");
                        Usuario u = cad.pesquisarUsuario(int.Parse(Console.ReadLine()));
                        Console.WriteLine(u != null ? u.ToString() : "Não encontrado.");
                        break;

                    case 6:
                        Console.Write("ID: ");
                        cad.removerUsuario(new Usuario(int.Parse(Console.ReadLine()), ""));
                        break;

                    case 7:
                        Console.Write("ID Usuário: ");
                        int u1 = int.Parse(Console.ReadLine());
                        Console.Write("ID Ambiente: ");
                        int a1 = int.Parse(Console.ReadLine());

                        Usuario user = cad.pesquisarUsuario(u1);
                        Ambiente amb = cad.pesquisarAmbiente(a1);

                        if (user != null && amb != null)
                        {
                            user.concederPermissao(amb);
                            Console.WriteLine("Permissão concedida.");
                        }
                        break;

                    case 8:
                        Console.Write("ID Usuário: ");
                        int u2 = int.Parse(Console.ReadLine());
                        Console.Write("ID Ambiente: ");
                        int a2 = int.Parse(Console.ReadLine());

                        Usuario user2 = cad.pesquisarUsuario(u2);
                        Ambiente amb2 = cad.pesquisarAmbiente(a2);

                        if (user2 != null && amb2 != null)
                        {
                            user2.revogarPermissao(amb2);
                            Console.WriteLine("Permissão revogada.");
                        }
                        break;

                    case 9:
                        Console.Write("ID Usuário: ");
                        int us = int.Parse(Console.ReadLine());
                        Console.Write("ID Ambiente: ");
                        int am = int.Parse(Console.ReadLine());
                        cad.registrarAcesso(am, us);
                        Console.WriteLine("Acesso registrado.");
                        break;

                    case 10:
                        Console.Write("ID Ambiente: ");
                        int am3 = int.Parse(Console.ReadLine());
                        Ambiente amb3 = cad.pesquisarAmbiente(am3);

                        if (amb3 != null)
                        {
                            foreach (Log log in amb3.Logs)
                                Console.WriteLine(log.ToString());
                        }
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
