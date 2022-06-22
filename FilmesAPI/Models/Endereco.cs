using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        [StringLength(50, ErrorMessage = "Esse campo não pode passar de 50 caracter")]
        public string Logradouro { get; set; }

        public string Bairro { get; set; }
        public int Numero { get; set; }

        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
