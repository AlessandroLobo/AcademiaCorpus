namespace AcademiaCorpus.Models;

public class Aluno
{
    public int AlunoId { get; set; }
    public string NomeAluno { get; set; }
    public DateTime DataNascimentoAluno { get; set; }
    public string FotoAlunoUrl { get; set; }
    public string EnderecoAluno { get; set; }
    public string EmailAluno { get; set; }

    public List<Treino> Treinos { get; set; }
}
