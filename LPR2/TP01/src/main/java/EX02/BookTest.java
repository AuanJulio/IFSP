package EX02;

import EX01.Author;

public class BookTest
{
    public static void main(String[] args) {

        Author[] authors = new Author[2];

        authors[0] = new Author("André Nascimento", "andrenasc@aluno.ifsp.edu.br", 'm');
        authors[1] = new Author("Auan Julio", "auanjulio@aluno.ifsp.edu.br", 'm');

        Book testBook = new Book("Java for noobies", authors, 19.99, 99);
        System.out.println(testBook.toString());

    }
}

