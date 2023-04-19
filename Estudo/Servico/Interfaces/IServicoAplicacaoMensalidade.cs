using Dominio.Entidades;
using Estudo.Models;

namespace Estudo.Servico.Interface
{
    public interface IServicoAplicacaoMensalidade
    {
        IEnumerable<MensalidadeViewModel> ListaMensalidade();

        MensalidadeViewModel CarregarRegistro(int codigo);

        void Cadastro(MensalidadeViewModel mensalidade);

        void Excluir(int codigo);
    }
}
