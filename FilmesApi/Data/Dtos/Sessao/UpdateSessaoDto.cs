using FilmesAPI.Models;
using System;

namespace FilmesApi.Data.Dtos.Sessao
{
    public class UpdateSessaoDto
    {
        public Cinema Cinema { get; set; }
        public Filme filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeIncio { get; set; }
    }
}
