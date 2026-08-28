using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using LivrariaCore;

// Auan Julio Galvão dos Santos - CB3030369

namespace LivrariaCommand.Data
{
    public class BookRepository
    {
        private readonly string caminhoArquivo;

        public BookRepository(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public List<Book> CarregarTodos(Dictionary<int, Author> autoresDisponiveis)
        {
            var livros = new List<Book>();

            if (!File.Exists(caminhoArquivo))
                return livros;

            var linhas = File.ReadAllLines(caminhoArquivo);

            for (int i = 1; i < linhas.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(linhas[i]))
                    continue;

                var campos = linhas[i].Split(';');
                string nome = campos[0];
                var idsAutores = campos[1].Split('|').Select(int.Parse);
                double preco = double.Parse(campos[2], CultureInfo.InvariantCulture);
                int qtd = int.Parse(campos[3]);

                var autoresDoLivro = idsAutores
                    .Where(id => autoresDisponiveis.ContainsKey(id))
                    .Select(id => autoresDisponiveis[id])
                    .ToArray();

                livros.Add(new Book(nome, autoresDoLivro, preco, qtd));
            }

            return livros;
        }

        public void Adicionar(Book livro, int[] idsAutores)
        {
            using var writer = new StreamWriter(caminhoArquivo, append: true);
            string precoTexto = livro.GetPrice().ToString(CultureInfo.InvariantCulture);
            string ids = string.Join("|", idsAutores);
            writer.WriteLine($"{livro.GetName()};{ids};{precoTexto};{livro.GetQty()}");
        }
    }
}
