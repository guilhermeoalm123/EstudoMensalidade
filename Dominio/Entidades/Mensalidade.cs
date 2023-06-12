using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Mensalidade: EntityBase
    {
        
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
		public byte Ativo { get; set; }

		public DateTime? DataCriacao { get; set; }

		ICollection<Pagamento> Pagamentos { get; set; }
	}
}
