using Aplicacao.Enums;
using Aplicacao.Servico;
using ClosedXML.Excel;
using Dominio.Entidades;
using Estudo.Models;
using Estudo.Servico;
using Estudo.Servico.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Estudo.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        readonly IServicoAplicacaoPagamento ServicoAplicacaoPagamento;
        //readonly IServicoAplicacaoPessoas ServicoAplicacaoPessoas;
        readonly IServicoAplicacaoKanban servicoAplicacaoKanban;

        public HomeController( IServicoAplicacaoKanban ServicoAplicacaoKanban, IServicoAplicacaoPagamento servicoAplicacaoPagamento)
        {
            //_logger = logger;
            ServicoAplicacaoPagamento = servicoAplicacaoPagamento;
            //ServicoAplicacaoPessoas = servicoAplicacaoPessoas;
            servicoAplicacaoKanban = ServicoAplicacaoKanban;
		}

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Privacy(int id)
        {
            kanbanViewModel kanbanViewModel = new kanbanViewModel();

            if (id != null)
            {
                kanbanViewModel = servicoAplicacaoKanban.ListarKanban((int)id);
            }
            else
            {
                kanbanViewModel = servicoAplicacaoKanban.CarregarApenasSelect();

			}

			return View(kanbanViewModel);
        }

        //public IActionResult Privacy(int codigo)
        //{
        //	kanbanViewModel kanbanViewModel = new kanbanViewModel();

        //	kanbanViewModel = servicoAplicacaoKanban.ListarKanban(codigo);

        //	return View(kanbanViewModel);
        //}

        [HttpGet]
        public IActionResult CadastrarPagamento(string id)
        {
             
            string[] aux = id.Split(";");

            PagamentoViewModel viewModel = new PagamentoViewModel()
            {
                PessoasCodigo = Convert.ToInt16((aux[0])),
				MensalidadeCodigo = Convert.ToInt16((aux[1]))
			};
			
			ServicoAplicacaoPagamento.Cadastro(viewModel);

			//ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, "Pagamento cadastrado!");
			return RedirectToAction("Privacy", "Home", new { id = Convert.ToInt16((aux[1])) });
		}

		[HttpGet]
		public IActionResult ExcluirPagamento(string id)
		{

			string[] aux = id.Split(";");

            PagamentoViewModel viewModel = new PagamentoViewModel();
            viewModel = ServicoAplicacaoPagamento.ListaPagamento().ToList().FirstOrDefault(x => x.MensalidadeCodigo == Convert.ToInt16(aux[1])
							&& x.PessoasCodigo == Convert.ToInt16((aux[0])));
                

			ServicoAplicacaoPagamento.Excluir((int)viewModel.Codigo);
			ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, "Pagamento Excluido!");
			return RedirectToAction("Privacy", "Home", new { id = Convert.ToInt16((aux[1])) });
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Excel(int id)
        {
            kanbanViewModel kanban = new kanbanViewModel();
            kanban = servicoAplicacaoKanban.ListarKanban(id);
            IEnumerable<PessoasViewModel> pessoas = (IEnumerable<PessoasViewModel>)kanban.ListaPessoasEmAtraso;
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Pessoas");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Código";
                worksheet.Cell(currentRow, 2).Value = "Nome";
                worksheet.Cell(currentRow, 3).Value = "CPF";
                foreach (var user in pessoas)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = user.Codigo;
                    worksheet.Cell(currentRow, 2).Value = user.Nome;
                    worksheet.Cell(currentRow, 3).Value = user.Cpf;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "mens-" + id.ToString() + "-" + DateTimeOffset.Now + ".xlsx");
                }
            }
        }
    }
}