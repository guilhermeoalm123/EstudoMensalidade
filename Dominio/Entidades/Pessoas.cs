using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Pessoas: EntityBase
    {
        
        public string Nome { get; set; }

		public string? Cpf { get; set; }

		public int Status { get; set; }

		public DateTime DataCriacao { get; set; }

		public virtual ICollection<Pagamento> Pagamento { get; set; }
	}
}
