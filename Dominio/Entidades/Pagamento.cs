using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Pagamento: EntityBase
    {
		[ForeignKey("Pessoas")]
		public int PessoasCodigo { get; set; }

		[ForeignKey("Mensalidade")]
		public int MensalidadeCodigo { get; set; }

		public virtual Pessoas Pessoas { get; set; }
		
		public virtual Mensalidade Mensalidade { get; set; }

		
	}
}
