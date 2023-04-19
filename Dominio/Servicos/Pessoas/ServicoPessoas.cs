using Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos.Pessoas
{
    public class ServicoPessoas: IServicoPessoas
    {
        IRepositorioPessoas RepositorioPessoas;
        public ServicoPessoas(IRepositorioPessoas repositorioPessoas) {
            RepositorioPessoas = repositorioPessoas; 
        }

        public IEnumerable<Entidades.Pessoas> ListarPessoas()
        {
            return RepositorioPessoas.Read();
            
        }
        public Entidades.Pessoas ListarPessoas(int Codigo)
        {
            return RepositorioPessoas.Read(Codigo);
        }

        public void Excluir(int id)
        {
            RepositorioPessoas.Delete(id);
        }

        public void Cadastrar(Entidades.Pessoas pessoas)
        {
            RepositorioPessoas.Create(pessoas);
        }

        
    }
}
