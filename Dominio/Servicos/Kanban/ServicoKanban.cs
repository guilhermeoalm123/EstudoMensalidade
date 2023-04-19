using Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorio;
using Dominio.Servicos.Pagamento;
using System.Collections;
using Dominio.Servicos.Mensalidade;

namespace Dominio.Servicos.Kanban
{
	public class ServicoKanban : IServicoKanban
	{
		IRepositorioKanban RepositorioKanban;
		IServicoPagamento ServicoPagamento;
		IServicoPessoas ServicoPessoas;
		IServicoMensalidade ServicoMensalidade;

		public ServicoKanban(IRepositorioKanban repositorioKanban, IServicoPagamento servicoPagamento, IServicoPessoas servicoPessoas, IServicoMensalidade servicoMensalidade)
		{
			RepositorioKanban = repositorioKanban;
			ServicoPagamento = servicoPagamento;
			ServicoPessoas = servicoPessoas;
			ServicoMensalidade = servicoMensalidade;
		}

		public Entidades.Kanban ListarKanban(int codigoMensalidade)
		{
			

			Entidades.Kanban kanban = new Entidades.Kanban()
			{
				Pagamento = (ICollection<Entidades.Pagamento>)ServicoPagamento.ListarPagamentoPorMensalidade(codigoMensalidade).ToList(),
				Pessoas = (ICollection<Entidades.Pessoas>)ServicoPessoas.ListarPessoas(),
				Mensalidades = ServicoMensalidade.ListarMensalidade()
				
			};

			List<Entidades.Pessoas> PessoasEmDia = new List<Entidades.Pessoas>();
			List<Entidades.Pessoas> PessoasEmAtraso = new List<Entidades.Pessoas>();
			
			foreach (var itemPessoas in kanban.Pessoas)				
			{

				Boolean achou = false;
				foreach (var itemPagamento in kanban.Pagamento)
				{
					if (itemPagamento.PessoasCodigo == itemPessoas.Codigo)
					{
						PessoasEmDia.Add(itemPessoas);
						achou = true;
					}
				}
				if (achou == false)
				{
					PessoasEmAtraso.Add(itemPessoas);
				}
				achou = false;
			}

			kanban.PessoasEmDia = PessoasEmDia;
			kanban.PessoasAtraso = PessoasEmAtraso;

			return kanban;
		}


	}
}
