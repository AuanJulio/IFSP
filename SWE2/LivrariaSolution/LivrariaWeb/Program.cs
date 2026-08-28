using LivrariaCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Author autor1 = new Author("Auan Julio", "auan.julio@gmail.com.br", 'M');
Author autor2 = new Author("Auan Autor", "auan.autor@gmail.com", 'M');
Book livro = new Book(
    "TP01 - SWE2",
    new Author[] { autor1, autor2 },
    37.50,
    7);

app.MapGet("/livro/nome", () => livro.GetName());

app.MapGet("/livro/tostring", () => livro.ToString());

app.MapGet("/livro/autores", () => livro.GetAuthorNames());

app.MapGet("/livro/ApresentarLivro", () =>
{
    string itensAutores = string.Join(
        "",
        Array.ConvertAll(livro.GetAuthors(), a => $"<li>{a.GetName()}</li>"));

    string html = $@"<!DOCTYPE html>
<html lang=""pt-br"">
<head>
    <meta charset=""utf-8"" />
    <title>Apresentar Livro</title>
</head>
<body>
    <h1>{livro.GetName()}</h1>
    <h2>Autores</h2>
    <ul>
        {itensAutores}
    </ul>
</body>
</html>";

    return Results.Content(html, "text/html; charset=utf-8");
});

app.Run();
