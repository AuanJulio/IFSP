using ProjBiblioteca;
using System;

namespace ProjBiblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Livros livros = new Livros();
            int opcao;

            do
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        Console.Write("ISBN: ");
                        int isbn = int.Parse(Console.ReadLine());
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("Editora: ");
                        string editora = Console.ReadLine();

                        livros.Adicionar(new Livro(isbn, titulo, autor, editora));
                        Console.WriteLine("✅ Livro adicionado!");
                        break;

                    case 2:
                        Console.Write("ISBN do livro: ");
                        Livro l1 = livros.Pesquisar(new Livro(int.Parse(Console.ReadLine()), "", "", ""));
                        if (l1 != null)
                            Console.WriteLine($"{l1}\nExemplares: {l1.QtdeExemplares()} | Disponíveis: {l1.QtdeDisponiveis()} | Empréstimos: {l1.QtdeEmprestimos()} | Disponibilidade: {l1.PercDisponibilidade():F2}%");
                        else
                            Console.WriteLine("Livro não encontrado.");
                        break;

                    case 3:
                        Console.Write("ISBN do livro: ");
                        Livro l2 = livros.Pesquisar(new Livro(int.Parse(Console.ReadLine()), "", "", ""));
                        if (l2 != null)
                            Console.WriteLine(l2.Analitico());
                        else
                            Console.WriteLine("Livro não encontrado.");
                        break;

                    case 4:
                        Console.Write("ISBN do livro: ");
                        Livro l3 = livros.Pesquisar(new Livro(int.Parse(Console.ReadLine()), "", "", ""));
                        if (l3 != null)
                        {
                            Console.Write("Tombo do exemplar: ");
                            int tombo = int.Parse(Console.ReadLine());
                            l3.AdicionarExemplar(new Exemplar(tombo));
                            Console.WriteLine("✅ Exemplar adicionado!");
                        }
                        else
                            Console.WriteLine("Livro não encontrado.");
                        break;

                    case 5:
                        Console.Write("ISBN do livro: ");
                        Livro l4 = livros.Pesquisar(new Livro(int.Parse(Console.ReadLine()), "", "", ""));
                        if (l4 != null)
                        {
                            Console.Write("Tombo do exemplar: ");
                            int tE = int.Parse(Console.ReadLine());
                            var ex = l4.BuscarExemplar(tE);
                            if (ex != null && ex.Emprestar())
                                Console.WriteLine("📚 Empréstimo registrado!");
                            else
                                Console.WriteLine("Não foi possível emprestar (exemplar indisponível ou não encontrado).");
                        }
                        else
                            Console.WriteLine("Livro não encontrado.");
                        break;

                    case 6:
                        Console.Write("ISBN do livro: ");
                        Livro l5 = livros.Pesquisar(new Livro(int.Parse(Console.ReadLine()), "", "", ""));
                        if (l5 != null)
                        {
                            Console.Write("Tombo do exemplar: ");
                            int tD = int.Parse(Console.ReadLine());
                            var ex = l5.BuscarExemplar(tD);
                            if (ex != null && ex.Devolver())
                                Console.WriteLine("✅ Devolução registrada!");
                            else
                                Console.WriteLine("Não foi possível devolver (exemplar não encontrado ou já devolvido).");
                        }
                        else
                            Console.WriteLine("Livro não encontrado.");
                        break;
                }

            } while (opcao != 0);
        }
    }
}