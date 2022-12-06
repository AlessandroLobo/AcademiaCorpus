using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiaCorpus.Models;

[Table("Treinos")]
public class Treino
{
    [Key]
    public int TreinosId { get; set; }

    [Required(ErrorMessage = "Informe o grupo Muscular")]
    [Display(Name = "Grupo Muscular")]
    [StringLength(100)]
    public string GrupoMuscular { get; set; }

    [Required(ErrorMessage = "Informe o nome do Musculo")]
    [Display(Name = "Musculo")]
    [StringLength(100)]
    public string Musculo { get; set; }

    [Required(ErrorMessage = "Informe a Serie")]
    [Display(Name = "Series")]
    public int Series { get; set; }

    [Required(ErrorMessage = "Informe o dia da Semana")]
    [Display(Name = "Dia da Semana")]
    [StringLength(50)]
    public string DiaDaSemana { get; set; }



    public int AlunoId { get; set; }
    public virtual Aluno Aluno { get; set; }
}
