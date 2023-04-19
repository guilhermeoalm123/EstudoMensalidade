using Dominio.Entidades;
using Dominio.Servicos.Pessoas;
using Estudo.Models;
using Estudo.Servico;
using Estudo.Servico.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.Data;

namespace Aplicacao.Controllers
{
    public class PagamentoController : Controller
    {
        readonly IServicoAplicacaoPagamento servicoAplicacaoPagamento;
        //readonly IServicoAplicacaoPessoas servicoAplicacaoPessoas;

        public PagamentoController(IServicoAplicacaoPagamento ServicoAplicacaoPagamento)
        {
            servicoAplicacaoPagamento = ServicoAplicacaoPagamento;
            //servicoAplicacaoPessoas = ServicoAplicacaoPessoas;
        }

        public IActionResult Index()
        {
            
			return View(servicoAplicacaoPagamento.ListaPagamento());
        }

        [HttpGet]
        public IActionResult Cadastrar(int id)
        {
			
			PagamentoViewModel viewModel = new PagamentoViewModel();
            
            viewModel = servicoAplicacaoPagamento.CarregarRegistro(id);
          

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(PagamentoViewModel pagamentoVm)
        {
            

			//if (ModelState.IsValid)
   //         {
                servicoAplicacaoPagamento.Cadastro(pagamentoVm);
            //}
            //else
            //{
            //    return View(pagamentoVm);
            //}

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            servicoAplicacaoPagamento.Excluir(id);
            return RedirectToAction("Index");
        }

        
    }
}
