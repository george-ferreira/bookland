using Microsoft.EntityFrameworkCore;

namespace bookland
{
    public class Livro
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Imagem { get; set; }
        public int Paginas { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}