using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private DBContext _context;
        private IGenreRepository _genreRepository;
        public GenresController(DBContext context, IGenreRepository genresRepository)
        {
            this._context = context;
            this._genreRepository = genresRepository;

        }

        [HttpGet("getGenre")]
        public Genres getGenre(int id)
        {
            return _genreRepository.getGenre(id);                  
        }
    }
}
