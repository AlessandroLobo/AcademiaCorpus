using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AcademiaCorpus.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Usuário")]
        public string UserName { get; internal set; }

        [Required(ErrorMessage = "Informe o senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; internal set; }
    }
}