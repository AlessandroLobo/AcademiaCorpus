using AcademiaCorpus.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaCorpus.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;



        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }




        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }


        //// O post é obrigatório para o método login
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel loginVM)
        //{
        //    if (!ModelState.IsValid)
        //        return View(loginVM);

        //    var user = await _userManager.FindByNameAsync(loginVM.UserName);

        //    if (user != null)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
        //        if (result.Succeeded)
        //        {
        //            if (string.IsNullOrEmpty(loginVM.ReturnUrl))
        //            {
        //                return RedirectToAction("index", "Home");
        //            }
        //            return Redirect(loginVM.ReturnUrl);
        //        }
        //    }
        //    ModelState.AddModelError("", "Falha ao realizer o login!!");
        //    return View(loginVM);
        //}
        // O post é obrigatório para o método login

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            // Validar os dados de login fornecidos pelo usuário
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            // Procurar o usuário pelo nome de usuário
            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            // Verificar se o usuário foi encontrado
            if (user == null)
            {
                // Adicionar erro ao modelo de estado para informar ao usuário que o nome de usuário é inválido
                ModelState.AddModelError("UserName", "Nome de usuário inválido");
                return View(loginVM);
            }

            // Verificar se a senha é válida para o usuário
            if (!await _userManager.CheckPasswordAsync(user, loginVM.Password))
            {
                // Adicionar erro ao modelo de estado para informar ao usuário que a senha é inválida
                ModelState.AddModelError("Password", "Senha inválida");
                return View(loginVM);
            }

            // Tentar fazer o login com o usuário e senha fornecidos
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (result.Succeeded)
            {
                // Verificar se o usuário está sendo redirecionado para uma URL específica após o login
                if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                {
                    // Redirecionar para a página inicial
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    // Redirecionar para a URL especificada
                    return Redirect(loginVM.ReturnUrl);
                }
            }

            // Se o login falhar, adicionar um erro ao modelo de estado para informar ao usuário
            ModelState.AddModelError("", "Falha ao realizar o login!");
            return View(loginVM);
        }



        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(LoginViewModel registroVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new IdentityUser { UserName = registroVM.UserName };
        //        var result = await _userManager.CreateAsync(user, registroVM.Password);

        //        if (result.Succeeded)
        //        {
        //            await _signInManager.SignInAsync(user, isPersistent: false);
        //            await _userManager.AddToRoleAsync(user, "Member");
        //            return RedirectToAction("Login", "Account");
        //        }
        //        else
        //        {
        //            this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
        //        }
        //    }
        //    return View(registroVM);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registroVM)
        {
            // Validar os dados de registro fornecidos pelo usuário
            if (!ModelState.IsValid)
            {
                return View(registroVM);
            }

            // Verificar se o nome de usuário já está sendo usado por outro usuário
            var existingUser = await _userManager.FindByNameAsync(registroVM.UserName);
            if (existingUser != null)
            {
                // Adicionar erro ao modelo de estado para informar ao usuário que o nome de usuário já está sendo usado
                ModelState.AddModelError("UserName", "Nome de usuário já está sendo usado");
                return View(registroVM);
            }

            // Criar novo usuário com o nome de usuário e senha fornecidos
            var user = new IdentityUser { UserName = registroVM.UserName };
            var result = await _userManager.CreateAsync(user, registroVM.Password);

            // Verificar se a criação do usuário foi bem-sucedida
            if (result.Succeeded)
            {
                // Fazer login com o novo usuário
                await _signInManager.SignInAsync(user, isPersistent: false);

                // Adicionar o usuário ao grupo "Membro"
                await _userManager.AddToRoleAsync(user, "Member");

                // Redirecionar o usuário para a página de login
                return RedirectToAction("Login", "Account");
            }
            else
            {
                // Adicionar erro ao modelo de estado para informar ao usuário que ocorreu um erro durante o registro
                ModelState.AddModelError("Registration", "Falha ao registrar o usuário");
                return View(registroVM);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    HttpContext.Session.Clear();
        //    HttpContext.User = null;
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Limpar a sessão atual
            HttpContext.Session.Clear();

            // Definir o usuário atual como nulo
            HttpContext.User = null;

            // Fazer logout do usuário atual
            await _signInManager.SignOutAsync();

            // Redirecionar o usuário para a página inicial
            return RedirectToAction("Index", "Home");
        }
    }
}