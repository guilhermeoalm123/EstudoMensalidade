using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Mensalidade: EntityBase
    {
        
        public string Descricao { get; set; }

		public decimal Valor { get; set; }
		public byte Ativo { get; set; }

		ICollection<Pagamento> Pagamentos { get; set; }
	}
}
