using System;
using LivrariaCore;

// Auan Julio Galvão dos Santos - CB3030369

namespace LivrariaCommand.Tests
{
    public static class BookTests
    {
        public static void ExecutarTestes()
        {
            var autor1 = new Author("Auan", "auan@gmail.com", 'M');
            var autor2 = new Author("Julio", "julio@gmail.com", 'M');
            var autores = new Author[] { autor1, autor2 };

            var livro1 = new Book("TP01SWE2", autores, 200.90);
            Console.WriteLine("Construtor (name, authors, price):");
            Console.WriteLine(livro1.ToString());
            Console.WriteLine($"Qty padrao (GetQty): {livro1.GetQty()}");
            Console.WriteLine();

            var livro2 = new Book("Sistemas Web 2", autores, 2000.01, 15);
            Console.WriteLine("Construtor (name, authors, price, qty):");
            Console.WriteLine(livro2.ToString());
            Console.WriteLine();

            Console.WriteLine($"GetName(): {livro2.GetName()}");

            Console.WriteLine("GetAuthors():");
            foreach (var autor in livro2.GetAuthors())
                Console.WriteLine($"  - {autor}");

            Console.WriteLine($"GetPrice(): {livro2.GetPrice()}");

            livro2.SetPrice(99.90);
            Console.WriteLine($"Apos SetPrice(99.90) -> GetPrice(): {livro2.GetPrice()}");

            Console.WriteLine($"GetQty(): {livro2.GetQty()}");

            livro2.SetQty(20);
            Console.WriteLine($"Apos SetQty(20) -> GetQty(): {livro2.GetQty()}");

            Console.WriteLine($"ToString(): {livro2.ToString()}");

            Console.WriteLine($"GetAuthorNames(): {livro2.GetAuthorNames()}");
        }
    }
}
