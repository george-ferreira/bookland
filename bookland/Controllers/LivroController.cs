using Microsoft.AspNetCore.Mvc;

namespace bookland.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly LivroContext _context;

        public LivroController(LivroContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllLivros()
        {
            var livros = _context.Livros.ToList();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public IActionResult GetLivro(int id) 
        {
            var livro = _context.Livros.FirstOrDefault(l => l.Id == id);
            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        public IActionResult PostLivro(Livro livro)
        {
            var l = new Livro { Nome = livro.Nome, 
                                Autor = livro.Autor, 
                                Titulo = livro.Titulo, 
                                Imagem = livro.Imagem, 
                                Paginas = livro.Paginas, 
                                DataInicio = livro.DataInicio.UtcDateTime, 
                                DataFim = livro.DataFim.UtcDateTime };

            _context.Livros.Add(l);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLivro(Livro livro, int id)
        {
            var livroExistente = _context.Livros.FirstOrDefault(l => l.Id == id);
            if (livroExistente != null)
            {
                livroExistente.Nome = livro.Nome;
                livroExistente.Autor = livro.Autor;
                livroExistente.Titulo = livro.Titulo;
                livroExistente.Imagem = livro.Imagem;
                livroExistente.Paginas = livro.Paginas;
                livroExistente.DataInicio = livro.DataInicio;
                livroExistente.DataFim = livro.DataFim;

                _context.SaveChanges();
            }
            else
                return NotFound();

            return Ok(livroExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLivro(int id) 
        {
            var livroExistente = _context.Livros.FirstOrDefault(l => l.Id == id);
            if (livroExistente != null)
            {
                _context.Livros.Remove(livroExistente);
                _context.SaveChanges();
            }
            else
                return NotFound();

            return Ok();
        }
    }
}
