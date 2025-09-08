package EX03;

/*
ALUNOS:
Auan Julio Galvão dos Santos
André Luiz Nascimento de Andrade

EXERCÍCIO 03:
Implemente o sistema representado pelo diagrama abaixo.
Obrigatório implementar uma classe de testes para todos os métodos das classes Staff e
Student.
 */

public class Person {

    private String name;
    private String address;

    public Person(String name, String address) {
        this.name = name;
        this.address = address;
    }

    public String getName() {
        return this.name;
    }

    public String getAddress() {
        return this.address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    @Override
    public String toString() {
        return String.format("Person[name=%s, address=%s]", name, address);
    }

}
