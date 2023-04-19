using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface
{
    public interface IServicoMensalidade
    {
        public IEnumerable<Mensalidade> ListarMensalidade();

        Mensalidade ListarMensalidade(int Codigo);

        void Cadastrar(Mensalidade mensalidade);

        void Excluir(int Codigo);

    }
}
