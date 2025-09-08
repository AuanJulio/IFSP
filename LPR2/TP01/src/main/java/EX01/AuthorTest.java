package EX01;

public class AuthorTest
{
    public static void main(String[] args) {

        Author auan = new Author("Auan Julio", "auanjulio@aluno.ifsp.edu.br", 'M');
        System.out.println(auan.toString());
        System.out.println(auan.getName());
        System.out.println(auan.getEmail());
        System.out.println(auan.getGender());

        auan.setEmail("auansantos@aluno.ifsp.edu.br");
        System.out.println(auan.getEmail());

    }
}
