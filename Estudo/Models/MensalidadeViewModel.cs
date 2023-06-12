using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Estudo.Models
{
    public class MensalidadeViewModel
    {
        public int? Codigo { get; set; }
        
        [Required(ErrorMessage ="*")]
        public string Descricao { get; set; }
		
        [Required(ErrorMessage = "*")]
		public decimal Valor { get; set; }
		public byte Ativo { get; set; }
		public DateTime DataCriacao { get; set; }


	}
}
