using Castle.Components.DictionaryAdapter;
using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace FilmesApi.Models
{
    public class Sessao
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Required]
        public  int Id { get; set; }
        public virtual Cinema cinema { get; set; }
        public virtual Filme filme { get; set; }
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DataSetDateTime HoraDeEncerramento { get; set; }
    }
}
