using Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos.Mensalidade
{
    public class ServicoMensalidade : IServicoMensalidade
    {
        IRepositorioMensalidade RepositorioMensalidade;
        public ServicoMensalidade(IRepositorioMensalidade repositorioMensalidade)
        {
            RepositorioMensalidade = repositorioMensalidade;
        }

        public IEnumerable<Entidades.Mensalidade> ListarMensalidade()
        {
            return RepositorioMensalidade.Read();

        }
        public Entidades.Mensalidade ListarMensalidade(int Codigo)
        {
            return RepositorioMensalidade.Read(Codigo);
        }

        public void Excluir(int id)
        {
            RepositorioMensalidade.Delete(id);
        }

        public void Cadastrar(Entidades.Mensalidade mensalidade)
        {
            RepositorioMensalidade.Create(mensalidade);
        }


    }
}
