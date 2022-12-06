namespace AcademiaCorpus.Models;

public class Treino
{
    public int TreinosId { get; set; }
    public string GrupoMuscular { get; set; }
    public string Musculo { get; set; }
    public int Series { get; set; }
    public string DiaDaSemana { get; set; }

    public int AlunoId { get; set; }
    public virtual Aluno Aluno { get; set; }
}
