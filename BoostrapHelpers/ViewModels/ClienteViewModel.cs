using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostrapHelpers.ViewModels
{
    public class ClienteViewModel
    {
        [Required]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Foto { get; set; }
    }
}
