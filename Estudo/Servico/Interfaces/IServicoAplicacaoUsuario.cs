using Dominio.Entidades;
using Estudo.Models;

namespace Estudo.Servico.Interface
{
    public interface IServicoAplicacaoUsuario
    {
        LoginViewModel Login(string email, string senha);
    }
}
