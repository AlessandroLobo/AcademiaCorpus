using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaCorpus.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
