using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IRepositorio<TEntidade>
        where TEntidade : class
    {
        void Create(TEntidade Entity);

        TEntidade Read(int ID);

        void Delete(int ID);

        IEnumerable<TEntidade> Read();


    }
}
