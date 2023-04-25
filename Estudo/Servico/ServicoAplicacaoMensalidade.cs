using Estudo .Models;
using Dominio.Interface;
using Estudo.Servico.Interface;
using Dominio.Entidades;

namespace Estudo.Servico
{
    public class ServicoAplicacaoMensalidade: IServicoAplicacaoMensalidade
    {
        private IServicoMensalidade ServicoMensalidade;
        

        public ServicoAplicacaoMensalidade(IServicoMensalidade servicoMensalidade)
        {
            ServicoMensalidade = servicoMensalidade;  
        }

        public void Cadastro(MensalidadeViewModel mensalidadeViewModel)
        {
            Mensalidade mensalidade = new Mensalidade()
            {
                Codigo = mensalidadeViewModel.Codigo,
                Descricao = mensalidadeViewModel.Descricao,
                Valor = mensalidadeViewModel.Valor,
                DataCriacao = DateTime.Now
            };

            ServicoMensalidade.Cadastrar(mensalidade);
        }

        public MensalidadeViewModel CarregarRegistro(int codigo)
        {
            
            var registro = ServicoMensalidade.ListarMensalidade(codigo);

            MensalidadeViewModel mensalidade = new MensalidadeViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao,
                Valor = registro.Valor,
                DataCriacao = registro.DataCriacao
            };

            return mensalidade;

        }

        public void Excluir(int codigo)
        {
            ServicoMensalidade.Excluir(codigo);
        }

        public IEnumerable<MensalidadeViewModel> ListaMensalidade()
        {
            var lista = ServicoMensalidade.ListarMensalidade();

            List<MensalidadeViewModel> listaMensalidade = new List<MensalidadeViewModel>();

            foreach (var item in lista)
            {
                MensalidadeViewModel mensalidade = new MensalidadeViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao,
                    Valor = item.Valor,
                    DataCriacao = DateTime.Now
                };

                listaMensalidade.Add(mensalidade);
            }
            return listaMensalidade;
        }


       
    }
}
