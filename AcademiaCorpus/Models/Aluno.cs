using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiaCorpus.Models;

[Table("Alunos")]
public class Aluno
{
    [Key]
    public int AlunoId { get; set; }

    [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
    [Required(ErrorMessage = "Informe o nome da categoria")]
    [Display(Name = "Nome")]
    public string NomeAluno { get; set; }

    [Required(ErrorMessage = "Digite a data de nascimento")]
    [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
    [Display(Name = "Data de nascimento")]
    public DateTime DataNascimentoAluno { get; set; }

    public string FotoAlunoUrl { get; set; }

    public string EnderecoAluno { get; set; }

    [Required(ErrorMessage = "Informe o seu email")]
    [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
    public string EmailAluno { get; set; }

    public List<Treino> Treinos { get; set; }
}
