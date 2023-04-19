using Estudo .Models;
using Dominio.Interface;
using Estudo.Servico.Interface;
using Dominio.Entidades;

namespace Estudo.Servico
{
    public class ServicoAplicacaoPessoas: IServicoAplicacaoPessoas
    {
        private IServicoPessoas ServicoPessoas;
        

        public ServicoAplicacaoPessoas(IServicoPessoas servicoPessoas)
        {
            ServicoPessoas = servicoPessoas;  
        }

        public void Cadastro(PessoasViewModel pessoasViewModel)
        {
            Pessoas pessoas = new Pessoas()
            {
                Codigo = pessoasViewModel.Codigo,
                Nome = pessoasViewModel.Nome,
                Status = pessoasViewModel.Status
            };

            ServicoPessoas.Cadastrar(pessoas);
        }

        public PessoasViewModel CarregarRegistro(int codigo)
        {
            
            var registro = ServicoPessoas.ListarPessoas(codigo);

            PessoasViewModel pessoas = new PessoasViewModel()
            {
                Codigo = registro.Codigo,
                Nome = registro.Nome,
                Status = registro.Status
            };

            return pessoas;

        }

        public void Excluir(int codigo)
        {
            ServicoPessoas.Excluir(codigo);
        }

        public IEnumerable<PessoasViewModel> ListaPessoas()
        {
            var lista = ServicoPessoas.ListarPessoas();

            List<PessoasViewModel> listaPessoas = new List<PessoasViewModel>();

            foreach (var item in lista)
            {
                PessoasViewModel pessoas = new PessoasViewModel()
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    Status = item.Status
                };

                listaPessoas.Add(pessoas);
            }
            return listaPessoas;
        }


       
    }
}
