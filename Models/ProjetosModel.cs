namespace Portifolio.Models
{
    public class ProjetosModel
    {
        public string? Nome { get; internal set; }
        public string? Descricao { get; internal set; }
        public string? Url { get; internal set; }

        public class GitHubProjectApiModel
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Url { get; set; }
        }
    }
}
