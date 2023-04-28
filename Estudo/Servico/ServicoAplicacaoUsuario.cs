using Estudo .Models;
using Dominio.Interface;
using Estudo.Servico.Interface;
using Dominio.Entidades;

namespace Estudo.Servico
{
    public class ServicoAplicacaoUsuario: IServicoAplicacaoUsuario
    {
        private IServicoUsuario ServicoUsuario;
        

        public ServicoAplicacaoUsuario(IServicoUsuario servicoUsuario)
        {
            ServicoUsuario = servicoUsuario;  
        }


        public LoginViewModel Login(string email, string senha)
        {
            
            var registro = ServicoUsuario.Login(email, senha);

            if (registro != null) 
            {
                LoginViewModel usuario = new LoginViewModel()
                {

                    Email = registro.Nome,
                    Senha = registro.Senha

                };

                return usuario;
            }
            

            return null;

        }

       
    }
}
