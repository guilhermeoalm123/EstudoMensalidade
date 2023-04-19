using Dominio.Entidades;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;



namespace Repositorio.Entidades
{
    public class RepositorioPagamento : Repositorio<Pagamento>, IRepositorioPagamento
    {
        public RepositorioPagamento(ApplicationDbContext dbContext): base(dbContext) {           
        }

		public virtual IEnumerable<Pagamento> Read()
		{
			return dbSetContext
				.Include(x=>x.Pessoas)
				.Include(x => x.Mensalidade)
				.AsNoTracking().ToList();
		}

	}
}
