using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.ViewModel
{
    public class UsuarioViewModel
    {
        [Required]

        public string Email { get; set; }

        [StringLength(250, MinimumLength = 5)]

        public string Senha { get; set; }

    }
}
