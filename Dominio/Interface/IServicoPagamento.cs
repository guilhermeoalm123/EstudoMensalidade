using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface
{
    public interface IServicoPagamento
    {
        public IEnumerable<Pagamento> ListarPagamento();

		public IEnumerable<Pagamento> ListarPagamentoPorMensalidade(int CodigoMensalidade);

		Pagamento ListarPagamento(int Codigo);

        void Cadastrar(Pagamento pagamento);

        void Excluir(int Codigo);

    }
}
