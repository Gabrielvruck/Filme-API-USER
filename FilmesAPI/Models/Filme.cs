using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo titulo é obrigatorio")]
        [StringLength(50, ErrorMessage = "Esse campo não pode passar de 50 caracter")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Genero é obrigatorio")]
        public string Genero { get; set; }
        [Required]
        public string Diretor { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no minimo 1 e no maximo 600 minutos")]
        public int Duracao { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
