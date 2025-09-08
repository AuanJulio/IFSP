package EX02;

import EX01.Author;

/*
ALUNOS:
Auan Julio Galvão dos Santos
André Luiz Nascimento de Andrade

EXERCÍCIO 02:
Um livro pode ser escrito por um ou muitos autores, por esta razão a classe Book deve
ter um array de autores, conforme o modelo abaixo:
- O construtor deve receber um array de autores
- Uma vez que o livro é instanciado o seu autor não pode ser adicionado ou removido.
- O método toString() deve retornar a seguinte resposta:
"Book[name=?,authors={Author[name=?,email=?,gender=?],......},price=?,qty=?]".
Você deve:
- Escrever um código para a classe Book, você deve reutilizar o código do Author
escrito no exercício 1
- Escrever uma classe de teste, chamada TestBook, para testar a classe Book.

Dicas:
// Crie e aloque o array de autores.
Author[] authors = new Author[2];
authors[0] = new Author("Autor 01", "autor01@somewhere.com.br", 'm');
authors[1] = new Author("Autor 02", "autor02@nowhere.com.br", 'm');

// Declarar e alocar a instância de um book.
Book testeBook = new Book("Java for Dummy", authors, 19.99, 99);
System.out.println(testeBook); // toString()
 */

import java.util.Arrays;

public class Book {

    private String name;
    private Author[] authors;
    private double price;
    private int qty = 0;

    public Book(String name, Author[] authors, double price) {
        this.name = name;
        this.authors = authors;
        this.price = price;
    }

    public Book(String name, Author[] authors, double price, int qty) {
        this.name = name;
        this.authors = authors;
        this.price = price;
        this.qty = qty;
    }

    public String getName() {
        return this.name;
    }

    public Author[] getAuthors() {
        return this.authors;
    }

    public double getPrice() {
        return this.price;
    }

    public int getQty() {
        return this.qty;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public void setQty(int qty) {
        this.qty = qty;
    }

    @Override
    public String toString() {
        return "Book[name=" + name +
                ", authors=" + Arrays.toString(authors) +
                ", price=" + price +
                ", qty=" + qty + "]";
    }

    public String getAuthorNames() {
        String ret = "";
        for(int i = 0; i < authors.length; i++) {
            ret += authors[i].getName() + ",";
        }
        return ret;
    }

}
