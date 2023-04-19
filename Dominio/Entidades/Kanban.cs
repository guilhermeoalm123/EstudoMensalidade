using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Kanban: EntityBase
    {

		public ICollection<Pagamento> Pagamento { get; set; }
		
		public ICollection<Pessoas> Pessoas { get; set; }

		public IEnumerable<Pessoas> PessoasEmDia { get; set; }

		public IEnumerable<Pessoas> PessoasAtraso { get; set; }

		public IEnumerable<Mensalidade> Mensalidades { get; set; }


		

	}
}
