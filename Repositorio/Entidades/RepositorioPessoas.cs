using Dominio.Entidades;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;



namespace Repositorio.Entidades
{
    public class RepositorioPessoas : Repositorio<Pessoas>, IRepositorioPessoas
    {
        public RepositorioPessoas(ApplicationDbContext dbContext): base(dbContext) {
            
        }
    }
}
