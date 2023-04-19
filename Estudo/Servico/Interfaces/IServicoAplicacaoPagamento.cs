using Dominio.Entidades;
using Estudo.Models;

namespace Estudo.Servico.Interface
{
    public interface IServicoAplicacaoPagamento
    {
        IEnumerable<PagamentoViewModel> ListaPagamento();

        PagamentoViewModel CarregarRegistro(int codigo);

        void Cadastro(PagamentoViewModel pagamento);

        void Excluir(int codigo);

    }
}
