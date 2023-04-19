using Estudo .Models;
using Dominio.Interface;
using Estudo.Servico.Interface;
using Dominio.Entidades;
using System.Net.NetworkInformation;
using Dominio.Servicos.Kanban;
using Dominio.Servicos.Mensalidade;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Estudo.Servico
{
    public class ServicoAplicacaoKanban: IServicoAplicacaoKanban
    {
        private IServicoKanban ServicoKanban;
		private IServicoMensalidade ServicoMensalidade;

        public ServicoAplicacaoKanban(IServicoKanban servicoKanban, IServicoMensalidade servicoMensalidade)
        {
            ServicoKanban = servicoKanban;
			ServicoMensalidade = servicoMensalidade;
        }

		public kanbanViewModel ListarKanban(int codigo)
        {
			Kanban kanban = new Kanban();
		    kanban = ServicoKanban.ListarKanban(codigo);

            kanbanViewModel kanbanViewModel = new kanbanViewModel();

			var convertPessoasEmDia = kanban.PessoasEmDia.Select(x => new PessoasViewModel
			{
				Codigo = x.Codigo,
				Nome = x.Nome,
				Status = x.Status,
			});

			var convertPessoasEmAtraso = kanban.PessoasAtraso.Select(x => new PessoasViewModel
			{
				Codigo = x.Codigo,
				Nome = x.Nome,
				Status = x.Status,
			});

			kanbanViewModel.ListaPessoasEmDia = convertPessoasEmDia;
			kanbanViewModel.ListaPessoasEmAtraso = convertPessoasEmAtraso;
			kanbanViewModel.MensalidadeCodigo = codigo;

			//kanbanViewModel.ListaMensalidade = (IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>)kanban.Mensalidades.ToList();
			List<SelectListItem> lista = new List<SelectListItem>();
			lista.Add(new SelectListItem
			{
				Text = string.Empty,
				Value = string.Empty
			});



			foreach (var item in kanban.Mensalidades)
			{
				lista.Add(new SelectListItem
				{
					Text = item.Descricao,
					Value = item.Codigo.ToString()
				});
			}
			kanbanViewModel.ListaMensalidade = lista;

			return kanbanViewModel;
		}

		public kanbanViewModel CarregarApenasSelect()
		{
			kanbanViewModel kanban = new kanbanViewModel();



			List<SelectListItem> lista = new List<SelectListItem>();
			lista.Add(new SelectListItem
			{
				Text = string.Empty,
				Value = string.Empty
			});



			foreach (var item in ServicoMensalidade.ListarMensalidade())
			{
				lista.Add(new SelectListItem
				{
					Text = item.Descricao,
					Value = item.Codigo.ToString()
				});
			}

			kanban.ListaMensalidade = lista;

			return kanban;
		}

	}
}
