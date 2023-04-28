using Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.Servicos.Usuario
{
    public class ServicoUsuario: IServicoUsuario
    {
        IRepositorioUsuario RepositorioUsuario;
        public ServicoUsuario(IRepositorioUsuario repositorioUsuario) {
            RepositorioUsuario = repositorioUsuario; 
        }

        
        public Entidades.Usuario Login(string email, string senha)
        {
            return RepositorioUsuario.Read().Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
        }

        
        
    }
}
