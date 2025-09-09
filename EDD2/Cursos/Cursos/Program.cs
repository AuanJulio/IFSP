using Cursos;

internal class Program
{
    static void Main(string[] args)
    {
        Escola escola = new Escola();

        Console.WriteLine(escola.adicionarCurso(new Curso(1, "ADS")) ? "Curso adicionado" : "Erro");
        Console.WriteLine(escola.adicionarCurso(new Curso(2, "Redes")) ? "Curso adicionado" : "Erro");

        Console.WriteLine(escola.mostrarCursos());

        Curso cursoPesq = escola.pesquisarCurso(new Curso(1));
        Console.WriteLine("Pesquisado: " + cursoPesq.ToString());

        cursoPesq.adicionarDisciplina(new Disciplina(101, "Estrutura de Dados"));
        cursoPesq.adicionarDisciplina(new Disciplina(102, "Banco de Dados"));

        Console.WriteLine(cursoPesq.mostrarDisciplinas());

        Disciplina discPesq = cursoPesq.pesquisarDisciplina(new Disciplina(101));
        Console.WriteLine("Pesquisada: " + discPesq.ToString());

        discPesq.matricularAluno(new Aluno(1, "João"));
        discPesq.matricularAluno(new Aluno(2, "Maria"));

        Console.WriteLine("Alunos da disciplina 101:\n" + discPesq.mostrarAlunos());

        Console.WriteLine(cursoPesq.removerDisciplina(new Disciplina(102)) ? "Disciplina removida" : "Erro");

        Console.WriteLine(escola.removerCurso(new Curso(2)) ? "Curso removido" : "Erro");

        Console.ReadKey();
    }
}
