using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dto
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "O campo Logradouro é obrigatorio")]
        [StringLength(50, ErrorMessage = "Esse campo não pode passar de 50 caracter")]
        public string Logradouro { get; set; }

        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
