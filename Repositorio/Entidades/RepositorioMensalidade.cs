using Dominio.Entidades;
using Dominio.Repositorio;
using Repositorio.Contexto;



namespace Repositorio.Entidades
{
    public class RepositorioMensalidade : Repositorio<Mensalidade>, IRepositorioMensalidade
    {
        public RepositorioMensalidade(ApplicationDbContext dbContext): base(dbContext) { }
    }
}
