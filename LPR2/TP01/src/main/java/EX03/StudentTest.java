package EX03;

public class StudentTest {
    public static void main(String[] args) {

        Student s = new Student("Auan", "Rua A", "ADS", 2023, 1500.50);

        System.out.println("Nome: " + s.getName());
        System.out.println("Endereço: " + s.getAddress());
        System.out.println("Programa: " + s.getProgram());
        System.out.println("Ano: " + s.getYear());
        System.out.println("Mensalidade: " + s.getFee());

        s.setProgram("Engenharia");
        s.setYear(2024);
        s.setFee(2000.75);
        s.setAddress("Rua B");

        System.out.println("\nApós alterações:");
        System.out.println("Programa: " + s.getProgram());
        System.out.println("Ano: " + s.getYear());
        System.out.println("Mensalidade: " + s.getFee());
        System.out.println("Endereço: " + s.getAddress());

        System.out.println("\nTeste toString:");
        System.out.println(s);
    }
}
