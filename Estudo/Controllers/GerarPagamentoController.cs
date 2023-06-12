using Aplicacao.Enums;
using Dominio.Entidades;
using Estudo.Models;
using Estudo.Servico.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
	public class GerarPagamentoController : Controller
    {
        readonly IServicoAplicacaoMensalidade servicoAplicacaoMensalidade;

        public GerarPagamentoController(IServicoAplicacaoMensalidade ServicoAplicacaoMensalidade)
        {
            servicoAplicacaoMensalidade = ServicoAplicacaoMensalidade;
        }


        [HttpGet]  
        public IActionResult Cadastrar(int id)
        {
            GerarPagamentoViewModel viewModel = new GerarPagamentoViewModel();
            //if (id != 0) {
            //    viewModel = servicoAplicacaoMensalidade.CarregarRegistro(id);
            //}
             
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(GerarPagamentoViewModel gerarPagamentoViewModel)
        {
            for (int i = 0; i < gerarPagamentoViewModel.Recorrencia; i++)
            {
                MensalidadeViewModel mensalidade = new MensalidadeViewModel()
                {
                    Ativo = 1,
                    DataCriacao = gerarPagamentoViewModel.DataInicio.AddMonths(i),
                    Descricao = "Mensalidade"
				};

				servicoAplicacaoMensalidade.Cadastro(mensalidade);



			}

   //         if (ModelState.IsValid) 
   //         {
   //             servicoAplicacaoMensalidade.Cadastro(mensalidadeVm);
   //         } 
   //         else
   //         {
			//	ViewBag.Alert = Servico.CommonServices.ShowAlert(Alerts.Danger, "Verifique os campos obrigatórios");
			//	return View(mensalidadeVm);
   //         }

			//ViewBag.Alert = Servico.CommonServices.ShowAlert(Alerts.Success, "Salvo com sucesso");
			return RedirectToAction("Index");

		}

        [HttpGet]
        public IActionResult Excluir(int id) {
            servicoAplicacaoMensalidade.Excluir(id);
            return RedirectToAction("Index");
        }

		
	}
}
