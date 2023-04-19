using Estudo.Models;
using Estudo.Servico.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
	public class MensalidadeController : Controller
    {
        readonly IServicoAplicacaoMensalidade servicoAplicacaoMensalidade;

        public MensalidadeController(IServicoAplicacaoMensalidade ServicoAplicacaoMensalidade)
        {
            servicoAplicacaoMensalidade = ServicoAplicacaoMensalidade;
        }

        public IActionResult Index()
        {
            return View(servicoAplicacaoMensalidade.ListaMensalidade());
        }

        [HttpGet]  
        public IActionResult Cadastrar(int id)
        {
            MensalidadeViewModel viewModel = new MensalidadeViewModel();
            if (id != 0) {
                viewModel = servicoAplicacaoMensalidade.CarregarRegistro(id);
            }
             
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(MensalidadeViewModel mensalidadeVm)
        {
            if (ModelState.IsValid) 
            {
                servicoAplicacaoMensalidade.Cadastro(mensalidadeVm);
            } 
            else
            {
                return View(mensalidadeVm);
            }

			return RedirectToAction("Index");

		}

        [HttpGet]
        public IActionResult Excluir(int id) {
            servicoAplicacaoMensalidade.Excluir(id);
            return RedirectToAction("Index");
        }

		
	}
}
