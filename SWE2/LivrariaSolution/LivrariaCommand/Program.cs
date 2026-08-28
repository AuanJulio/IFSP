using System;
using System.IO;
using LivrariaCommand.Data;
using LivrariaCommand.Tests;

// Auan Julio Galvão dos Santos - CB3030369

namespace LivrariaCommand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string pastaDados = Path.Combine(AppContext.BaseDirectory, "Data");
            string caminhoAutores = Path.Combine(pastaDados, "autores.csv");
            string caminhoLivros = Path.Combine(pastaDados, "livros.csv");

            Console.WriteLine("=== Leitura do repositorio de dados (arquivos CSV) ===");

            var repositorioAutores = new AuthorRepository(caminhoAutores);
            var autores = repositorioAutores.CarregarTodos();
            Console.WriteLine($"Autores carregados: {autores.Count}");

            var repositorioLivros = new BookRepository(caminhoLivros);
            var livros = repositorioLivros.CarregarTodos(autores);
            Console.WriteLine($"Livros carregados: {livros.Count}");
            Console.WriteLine();

            foreach (var livro in livros)
                Console.WriteLine(livro.ToString());

            Console.WriteLine();
            Console.WriteLine("=== Classe de testes (Book) ===");
            BookTests.ExecutarTestes();

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
