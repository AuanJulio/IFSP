package EX01;

/*
ALUNOS:
Auan Julio Galvão dos Santos
André Luiz Nascimento de Andrade

EXERCÍCIO 01:
Uma classe chamada Author é desenhada para servir de modelo para autores de livros,
veja abaixo:
- 3 atributos privados name (String), email (String), and gender (char contendo 'm' or
'f');
- Um construtor para inicializar os atributos com base nos 3 parâmetros.
- Não existe um construtor default para Author [Author()].
- Criar métodos públicos: getName(), getEmail(), setEmail(), and getGender().
- Não existe setter para name e gender, estes atributos não podem ser alterados.
- Um método chamado toString() que retorna "Author[name=?,email=?,gender=?]",
exemplo "Author[name=Wellington Tuler,email=tulermoraes@yahoo.com,gender=m]".
- Escreva a classe Author e desenvolva uma de teste, com os seguintes itens:

- Testar construtor.
- Verificar o método toString().
- Testar o Setter
- Testar os Getters
 */

public class Author {

    private String name;
    private String email;
    private char gender;

    public Author(String name, String email, char gender) {
        gender = Character.toLowerCase(gender);
        if(gender != 'f' && gender != 'm') {
            throw new RuntimeException("O Genero deve ser 'F' ou 'M'");
        }
        this.name = name;
        this.email = email;
        this.gender = gender;
    }

    public String getName() {
        return this.name;
    }

    public String getEmail() {
        return this.email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public char getGender() {
        return this.gender;
    }

    @Override
    public String toString() {
        return String.format("Author[name=%s, email=%s, gender=%c]", name, email, gender);
    }
}
