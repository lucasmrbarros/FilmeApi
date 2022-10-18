using Microsoft.VisualBasic;

namespace FilmesApi.Data.Sessao
{
    public class CreateSessaoDto
    {
        public int IdCinema { get; set; }
        public int IdFilme { get; set; }
        public DateAndTime HorarioDeEncerramento { get; set; }
    }
}
