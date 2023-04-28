using Aplicacao.Helpers;
using Estudo.Models;
using Estudo.Servico.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{

	public class LoginController : Controller
	{
        readonly IServicoAplicacaoUsuario servicoAplicacaoUsuario;

		public LoginController(IServicoAplicacaoUsuario ServicoAplicacaoUsuario)
		{
			servicoAplicacaoUsuario	= ServicoAplicacaoUsuario;
		}

        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
			ViewData["Erro"] = string.Empty;
			var senha = string.Empty;
			if (ModelState.IsValid)
			{
                Criptografia criptografia = new Criptografia();
                senha = criptografia.GerarMD5(model.Senha);

				var login = servicoAplicacaoUsuario.Login(model.Email, senha);
				if (login == null)
				{
                    ViewData["Erro"] = "Dados incorretos!";
                    return View(model);
                }
            }
			else
			{
				ViewData["Erro"] = "Preencha corretamente o e-mail e a senha!";
                return View(model);
            }
            return RedirectToAction("index","home");

        }
    }
}
