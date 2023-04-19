using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface
{
    public interface IServicoPessoas
    {
        public IEnumerable<Pessoas> ListarPessoas();

        Pessoas ListarPessoas(int Codigo);

        void Cadastrar(Pessoas pessoas);

        void Excluir(int Codigo);

    }
}
