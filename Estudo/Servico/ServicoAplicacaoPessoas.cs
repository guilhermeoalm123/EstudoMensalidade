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
				Cpf = pessoasViewModel.Cpf,
				Status = pessoasViewModel.Status,
                DataCriacao = DateTime.Now
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
				Cpf = registro.Cpf,
				Status = registro.Status,
                DataCriacao = registro.DataCriacao
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
                    Cpf = item.Cpf,
                    Status = item.Status,
                    DataCriacao = item.DataCriacao
                };

                listaPessoas.Add(pessoas);
            }
            return listaPessoas;
        }


       
    }
}
