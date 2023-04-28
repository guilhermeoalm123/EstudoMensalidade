using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Repositorio.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Pessoas> Pessoas { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<Mensalidade> Mensalidade { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<Pagamento> Pagamento { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Usuario> Usuario { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}
}
