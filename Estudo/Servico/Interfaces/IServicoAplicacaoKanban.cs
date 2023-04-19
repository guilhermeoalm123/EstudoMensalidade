using Dominio.Entidades;
using Estudo.Models;

namespace Estudo.Servico.Interface
{
    public interface IServicoAplicacaoKanban
    {
        kanbanViewModel ListarKanban(int codigo);

        kanbanViewModel CarregarApenasSelect();

	}
}
