using Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos.Pagamento
{
    public class ServicoPagamento : IServicoPagamento
    {
        IRepositorioPagamento RepositorioPagamento;
        public ServicoPagamento(IRepositorioPagamento repositorioPagamento) {
            RepositorioPagamento = repositorioPagamento; 
        }

		public ServicoPagamento()
		{
		}

		public IEnumerable<Entidades.Pagamento> ListarPagamento()
        {
            return RepositorioPagamento.Read();
            
        }
        public Entidades.Pagamento ListarPagamento(int Codigo)
        {
            return RepositorioPagamento.Read(Codigo);
        }

        public void Excluir(int id)
        {
            RepositorioPagamento.Delete(id);
        }

        public void Cadastrar(Entidades.Pagamento pagamento)
        {
            RepositorioPagamento.Create(pagamento);
        }

		public IEnumerable<Entidades.Pagamento> ListarPagamentoPorMensalidade(int CodigoMensalidade)
		{
			return RepositorioPagamento.Read().Where(x => x.MensalidadeCodigo == CodigoMensalidade);
		}
	}
}
