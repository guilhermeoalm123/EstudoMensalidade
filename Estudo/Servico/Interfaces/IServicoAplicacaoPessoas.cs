using Dominio.Entidades;
using Estudo.Models;

namespace Estudo.Servico.Interface
{
    public interface IServicoAplicacaoPessoas
    {
        IEnumerable<PessoasViewModel> ListaPessoas();

        PessoasViewModel CarregarRegistro(int codigo);

        void Cadastro(PessoasViewModel pessoas);

        void Excluir(int codigo);
    }
}
