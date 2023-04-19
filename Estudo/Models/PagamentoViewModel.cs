using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Estudo.Models
{
    public class PagamentoViewModel
    {
        public int? Codigo { get; set; }
           
        public int PessoasCodigo { get; set; }
		//public Pessoas Pessoas { get; set; }
		public string PessoasNome { get; set; }
		public IEnumerable<SelectListItem> ListaPessoa { get; set; }
     
		public int MensalidadeCodigo { get; set; }
		//public Mensalidade Mensalidade { get; set; }
		public string MensalidadeDescricao { get; set; }

		public IEnumerable<SelectListItem> ListaMensalidade { get; set; }

	}
}
