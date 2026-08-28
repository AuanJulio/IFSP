using System.Collections.Generic;
using System.IO;
using LivrariaCore;

// Auan Julio Galvão dos Santos - CB3030369

namespace LivrariaCommand.Data
{
    public class AuthorRepository
    {
        private readonly string caminhoArquivo;

        public AuthorRepository(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public Dictionary<int, Author> CarregarTodos()
        {
            var autores = new Dictionary<int, Author>();

            if (!File.Exists(caminhoArquivo))
                return autores;

            var linhas = File.ReadAllLines(caminhoArquivo);

            for (int i = 1; i < linhas.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(linhas[i]))
                    continue;

                var campos = linhas[i].Split(',');
                int id = int.Parse(campos[0]);
                string nome = campos[1];
                string email = campos[2];
                char genero = campos[3][0];

                autores[id] = new Author(nome, email, genero);
            }

            return autores;
        }
    }
}
