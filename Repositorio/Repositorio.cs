

using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repositorio
{
    public abstract class Repositorio<TEntidade> : DbContext, IRepositorio<TEntidade>
        where TEntidade : EntityBase, new()
    {
        DbContext Db;
        protected DbSet<TEntidade> dbSetContext;

        public Repositorio(DbContext dbContext)
        {
            Db = dbContext;
            dbSetContext = Db.Set<TEntidade>();

        }

        public void Create(TEntidade Entity)
        {
            if (Entity.Codigo == null)
            {
                dbSetContext.Add(Entity);
            }
            else
            {
                dbSetContext.Entry(Entity).State = EntityState.Modified;
            }

            Db.SaveChanges();

        }

        public void Delete(int ID)
        {
            var ent = new TEntidade { Codigo = ID };
            dbSetContext.Attach(ent);
            dbSetContext.Remove(ent);
            Db.SaveChanges();
        }

        public TEntidade Read(int ID)
        {    
            return dbSetContext.Where(x => x.Codigo == ID).FirstOrDefault();
        }

        public virtual IEnumerable<TEntidade> Read()
        {
            return dbSetContext.AsNoTracking().ToList();
        }
    }
}