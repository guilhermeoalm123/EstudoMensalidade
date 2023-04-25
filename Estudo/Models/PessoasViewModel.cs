using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Estudo.Models
{
    public class PessoasViewModel
    {
        public int? Codigo { get; set; }
        
        [Required(ErrorMessage ="*")]
        public string Nome { get; set; }

		public string Cpf { get; set; }

		public int Status { get; set; }

		public DateTime DataCriacao { get; set; }

	}
}
