using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Estudo.Models
{
    public class GerarPagamentoViewModel
    {
        public int Recorrencia { get; set; }
        
		public DateTime DataInicio { get; set; }
        public string Prefixo { get; set; }

    }
}
