using Dominio.Entidades;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;



namespace Repositorio.Entidades
{
    public class RepositorioKanban : Repositorio<Kanban>, IRepositorioKanban
    {
        public RepositorioKanban(ApplicationDbContext dbContext): base(dbContext) {
            
        }
    }
}
