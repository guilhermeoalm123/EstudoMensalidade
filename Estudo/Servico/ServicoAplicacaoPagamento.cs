using Estudo .Models;
using Dominio.Interface;
using Estudo.Servico.Interface;
using Dominio.Entidades;
using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dominio.Servicos.Pessoas;

namespace Estudo.Servico
{
    public class ServicoAplicacaoPagamento: IServicoAplicacaoPagamento
    {
        private IServicoPagamento ServicoPagamento;
        private IServicoPessoas ServicoPessoas;
		private IServicoMensalidade ServicoMensalidade;

		public ServicoAplicacaoPagamento(IServicoPagamento servicoPagamento, 
            IServicoPessoas servicoPessoas, 
            IServicoMensalidade servicoMensalidade)
        {
            ServicoPagamento = servicoPagamento;
            ServicoPessoas = servicoPessoas;
			ServicoMensalidade =  servicoMensalidade;

		}

        public void Cadastro(PagamentoViewModel pagamentoViewModel)
        {
			//pagamentoViewModel.ListaPessoa = ListaPessoa();
			//pagamentoViewModel.ListaMensalidade = ListaMensalidade();

			Pagamento pagamento = new Pagamento()
            {
                Codigo = pagamentoViewModel.Codigo,
                PessoasCodigo = pagamentoViewModel.PessoasCodigo,
                MensalidadeCodigo = pagamentoViewModel.MensalidadeCodigo
			};

            ServicoPagamento.Cadastrar(pagamento);
        }

        public PagamentoViewModel CarregarRegistro(int codigo)
        {
            PagamentoViewModel pagamento = new PagamentoViewModel();

			pagamento.ListaPessoa = ListaPessoa();
			pagamento.ListaMensalidade = ListaMensalidade();

			if(codigo > 0) { 
			var registro = ServicoPagamento.ListarPagamento(codigo);

            pagamento.Codigo = registro.Codigo;
            //pagamento.Pessoas = registro.Pessoas;
            //pagamento.Mensalidade = registro.Mensalidade;
			pagamento.PessoasCodigo = registro.PessoasCodigo;
			pagamento.MensalidadeCodigo = registro.MensalidadeCodigo;
			}

			return pagamento;

        }

		private IEnumerable<SelectListItem> ListaPessoa()
		{
			List<SelectListItem> lista = new List<SelectListItem>();
			lista.Add(new SelectListItem
			{
				Text = string.Empty,
				Value = string.Empty
			});

			foreach (var item in ServicoPessoas.ListarPessoas())
			{
				lista.Add(new SelectListItem
				{
					Text = item.Nome,
					Value = item.Codigo.ToString()
				});
			}
			return lista;

		}

		private IEnumerable<SelectListItem> ListaMensalidade()
		{
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
			return lista;

		}

		public void Excluir(int codigo)
        {
            ServicoPagamento.Excluir(codigo);
        }

        public IEnumerable<PagamentoViewModel> ListaPagamento()
        {
            var lista = ServicoPagamento.ListarPagamento();

            List<PagamentoViewModel> listaPagamento = new List<PagamentoViewModel>();

            foreach (var item in lista)
            {
                PagamentoViewModel pagamento = new PagamentoViewModel()
                {
                    Codigo = item.Codigo,
                    PessoasNome = item.Pessoas.Nome,
                    MensalidadeDescricao = item.Mensalidade.Descricao,
					PessoasCodigo = item.PessoasCodigo,
					MensalidadeCodigo = item.MensalidadeCodigo
                };

                listaPagamento.Add(pagamento);
            }
            return listaPagamento;
        }

		
	}
}
