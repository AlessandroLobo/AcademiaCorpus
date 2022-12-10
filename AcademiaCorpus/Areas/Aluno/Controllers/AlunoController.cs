using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaCorpus.Areas.Aluno.Controllers
{
    public class AlunoController : Controller
    {
        [Area("Aluno")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
