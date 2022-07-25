namespace Exo.WebApi.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public DateTime? DataInicio { get; set; }
        public string? Tecnologia { get; set; }
        public string? Area { get; set; }
    }
}
