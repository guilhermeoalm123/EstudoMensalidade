﻿using Estudo.Models;
using Estudo.Servico.Interface;
using Microsoft.AspNetCore.Mvc;
using Aplicacao.Enums;

namespace Aplicacao.Controllers
{
    public class PessoasController : Controller
    {
        readonly IServicoAplicacaoPessoas servicoAplicacaoPessoas;

        public PessoasController(IServicoAplicacaoPessoas ServicoAplicacaoPessoas)
        {
            servicoAplicacaoPessoas = ServicoAplicacaoPessoas;
        }

        public IActionResult Index()
        {
            return View(servicoAplicacaoPessoas.ListaPessoas());
        }

        [HttpGet]  
        public IActionResult Cadastrar(int id)
        {
            PessoasViewModel viewModel = new PessoasViewModel();
            if (id != 0) {
                viewModel = servicoAplicacaoPessoas.CarregarRegistro(id);
            }
             
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(PessoasViewModel pessoasVm)
        {
            if (ModelState.IsValid) 
            {
				
				servicoAplicacaoPessoas.Cadastro(pessoasVm);
            } 
            else
            {
				ViewBag.Alert = Servico.CommonServices.ShowAlert(Alerts.Danger, "Verifique os campos obrigatórios");
				return View(pessoasVm);
            }

			ViewBag.Alert = Servico.CommonServices.ShowAlert(Alerts.Success, "Salvo com sucesso");
			return View(pessoasVm);

		}



        [HttpGet]
        public IActionResult Excluir(int id) {
            servicoAplicacaoPessoas.Excluir(id);
            return RedirectToAction("Index");
        }

		//[HttpGet]
		//public IActionResult AlterarStatus(int id, int mensalidade)
		//{
		//	PessoasViewModel viewModel = new PessoasViewModel();
		//	if (id != 0)
		//	{
		//		viewModel = servicoAplicacaoPessoas.CarregarRegistro(id);
		//	}
		//          viewModel.Status = 2;
		//	servicoAplicacaoPessoas.Cadastro(viewModel);
		//	return RedirectToAction("Privacy", "Home");
		//}

		//[HttpGet]
		//public IActionResult AlterarStatusPara1(string id)
		//{
		//	string[] aux = id.Split(";");
		//	PessoasViewModel viewModel = new PessoasViewModel();
		//	if (id != "")
		//	{		
		//              viewModel = servicoAplicacaoPessoas.CarregarRegistro(Convert.ToInt16((aux[0])));
		//	}
		//	viewModel.Status = 1;
		//	servicoAplicacaoPessoas.Cadastro(viewModel);
		//	return RedirectToAction("Privacy", "Home", new { id = Convert.ToInt16((aux[1])) });
		//}

		

	}
}
