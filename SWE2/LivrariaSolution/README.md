# Livraria — Solução Visual Studio

Solução com 3 projetos:

- **LivrariaCore** — biblioteca de classes com `Book` e `Author` (o diagrama UML).
- **LivrariaCommand** — projeto Console ("Command"), com o repositório em CSV e a classe de testes.
- **LivrariaWeb** — projeto ASP.NET Core (Minimal API) com as 4 rotas.

Requer **.NET 8 SDK** instalado (obs.: este ambiente de geração de arquivos não tem o SDK
instalado, então os comandos abaixo não puderam ser executados aqui — rode-os na sua máquina
com o Visual Studio / `dotnet` instalado para gerar o executável e capturar o Prompt pedido no item 1-D).

## Item 1 — A, B, C

Abra `LivrariaSolution.sln` no Visual Studio (ou rode pelo terminal na pasta da solução):

```
dotnet build
```

- **A** — As entidades `Book` e `Author` estão em `LivrariaCore/Book.cs` e `LivrariaCore/Author.cs`,
  seguindo exatamente os atributos e métodos do diagrama (dois construtores, getters/setters,
  `ToString()` no formato `Book[name=...,authors={Author[...],...},price=...,qty=...]` e
  `GetAuthorNames()` retornando `"nomeAutor1,nomeAutor2"`).
- **B** — A conexão com o repositório de dados está em `LivrariaCommand/Data`, usando arquivos
  CSV (`autores.csv` e `livros.csv`), lidos por `AuthorRepository` e `BookRepository` — no mesmo
  estilo usado nas aulas 1 e 2. Se preferir SQL Server, basta trocar a implementação interna
  desses dois repositórios por `SqlConnection`/`SqlCommand`, mantendo a mesma assinatura pública
  (`CarregarTodos(...)`), sem alterar o restante do projeto.
- **C** — `LivrariaCommand/Tests/BookTests.cs` cria um livro com dois autores e chama todos os
  métodos de `Book` (os dois construtores, `GetName`, `GetAuthors`, `GetPrice`, `SetPrice`,
  `GetQty`, `SetQty`, `ToString`, `GetAuthorNames`).

## Item 1 — D (gerar o executável)

No terminal, dentro da pasta `LivrariaCommand`:

```
dotnet publish -c Release -r win-x64 --self-contained false -o publish
```

Isso gera `publish\LivrariaCommand.exe`. Para rodar e capturar o Prompt pedido:

```
cd publish
LivrariaCommand.exe
```

Saída esperada (resumida):

```
=== Leitura do repositorio de dados (arquivos CSV) ===
Autores carregados: 3
Livros carregados: 3

Book[name=Introducao a Orientacao a Objetos,authors={Author[name=Ana Souza,email=ana.souza@editora.com.br,gender=F],Author[name=Carlos Lima,email=carlos.lima@editora.com.br,gender=M]},price=89.9,qty=12]
Book[name=Estruturas de Dados em C#,authors={Author[name=Beatriz Rocha,email=beatriz.rocha@editora.com.br,gender=F]},price=74.5,qty=7]
Book[name=Algoritmos Avancados,authors={Author[name=Ana Souza,email=ana.souza@editora.com.br,gender=F]},price=99,qty=4]

=== Classe de testes (Book) ===
Construtor (name, authors, price):
Book[name=Introducao a Orientacao a Objetos,authors={Author[name=Ana Souza,...],Author[name=Carlos Lima,...]},price=89.9,qty=0]
Qty padrao (GetQty): 0

Construtor (name, authors, price, qty):
Book[name=Estruturas de Dados Avancadas,authors={...},price=129.5,qty=15]

GetName(): Estruturas de Dados Avancadas
GetAuthors():
  - Author[name=Ana Souza,...]
  - Author[name=Carlos Lima,...]
GetPrice(): 129.5
Apos SetPrice(99.90) -> GetPrice(): 99.9
GetQty(): 15
Apos SetQty(20) -> GetQty(): 20
ToString(): Book[name=Estruturas de Dados Avancadas,authors={...},price=99.9,qty=20]
GetAuthorNames(): Ana Souza,Carlos Lima
```

Tire o print do console (Prompt) mostrando exatamente essa execução para entregar o item D.

## Item 2 — A, B

- **A** — `LivrariaWeb` é o projeto Web hospedado dentro da mesma solução do item 1
  (`app.MapGet`, ASP.NET Core Minimal API).
- **B** — Rode com:

```
cd LivrariaWeb
dotnet run
```

O console mostrará a URL (ex.: `http://localhost:5232`). Rotas disponíveis:

| Rota | Retorna |
|---|---|
| `GET /livro/nome` | `Introducao a Orientacao a Objetos` |
| `GET /livro/tostring` | `Book[name=...,authors={...},price=89.9,qty=12]` |
| `GET /livro/autores` | `Ana Souza,Carlos Lima` |
| `GET /livro/ApresentarLivro` | Página HTML com o nome do livro e a lista de autores em `<ul>` |

Teste no navegador ou com `curl`:

```
curl http://localhost:5232/livro/nome
curl http://localhost:5232/livro/tostring
curl http://localhost:5232/livro/autores
curl http://localhost:5232/livro/ApresentarLivro
```
