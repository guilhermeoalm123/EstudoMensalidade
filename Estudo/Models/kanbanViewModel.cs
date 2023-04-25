using Microsoft.AspNetCore.Mvc.Rendering;

namespace Estudo.Models
{
	public class kanbanViewModel
	{
		public IEnumerable<SelectListItem> ListaMensalidade { get; set; }

		public IEnumerable<PessoasViewModel> ListaPessoasEmDia { get; set; }

		public IEnumerable<PessoasViewModel> ListaPessoasEmAtraso { get; set; }

		public int MensalidadeCodigo { get; set; }

		public DateTime? MensalidadeDataCriacao { get; set; }
	}
}
