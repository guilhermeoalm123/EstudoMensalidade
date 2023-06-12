using Aplicacao.Enums;
using Aplicacao.Helpers;
using Dominio.Entidades;
using Estudo.Models;
using Estudo.Servico.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Aplicacao.Controllers
{

	public class LoginController : Controller
	{
        readonly IServicoAplicacaoUsuario servicoAplicacaoUsuario;
        readonly IHttpContextAccessor HttpContexto;

        public LoginController(IServicoAplicacaoUsuario ServicoAplicacaoUsuario, IHttpContextAccessor httpContexto)
		{
			servicoAplicacaoUsuario	= ServicoAplicacaoUsuario;
            HttpContexto = httpContexto;
		}

        public IActionResult Index(int? id)
		{
			if (id == 0)
			{
				HttpContexto.HttpContext.Session.Clear();
			}
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
                else
				{
                    HttpContexto.HttpContext.Session.SetInt32(Sessao.Logado, 1);
					HttpContexto.HttpContext.Session.SetString(Sessao.Email, model.Email);
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
