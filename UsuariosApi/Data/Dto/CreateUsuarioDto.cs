using System;
using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dto
{
    public class CreateUsuarioDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
