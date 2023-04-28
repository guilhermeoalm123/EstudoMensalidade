using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Estudo.Models
{
    public class LoginViewModel
    {

		public string Email { get; set; }

		public string Senha { get; set; }

	}
}
