using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Repositorio.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pessoas> Pessoas { get; set; }
		public DbSet<Mensalidade> Mensalidade { get; set; }
		public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}
}
