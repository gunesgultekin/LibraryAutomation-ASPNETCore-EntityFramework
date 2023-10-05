
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthorsContoller  : ControllerBase
    {
        private DBContext _context;
        private IAuthorRepository authorRepository;

        public AuthorsContoller(DBContext context, IAuthorRepository authorRepository)
        {
            this._context = context;
            this.authorRepository = authorRepository;
        }

        [HttpGet("getAuthorInfo")]
        public Authors getAuthorInfo(int authorID)
        {
            return authorRepository.getAuthorInfo(authorID);

        }

        [HttpGet("getAll")]
        public Task<List<Authors>> GetAll()
        {
            return authorRepository.GetAll();
        }
    }
}
