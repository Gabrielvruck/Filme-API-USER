using FilmesAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dto.Gerente
{
    public class ReadGerenteDto
    {
        [Key]
        [Required]
        public int  Id { get; set; }
        public string  Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
