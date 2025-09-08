package EX03;

public class StaffTest {

    public static void main(String[] args) {
        Staff st = new Staff("André Nascimento", "Rua C", "Escola X", 3000.75);

        System.out.println("Nome: " + st.getName());
        System.out.println("Endereço: " + st.getAddress());
        System.out.println("Escola: " + st.getSchool());
        System.out.println("Salário: " + st.getPay());

        st.setSchool("Escola Y");
        st.setPay(3500.90);
        st.setAddress("Rua D");

        System.out.println("\nApós alterações:");
        System.out.println("Escola: " + st.getSchool());
        System.out.println("Salário: " + st.getPay());
        System.out.println("Endereço: " + st.getAddress());

        System.out.println("\nTeste toString:");
        System.out.println(st);
    }

}
