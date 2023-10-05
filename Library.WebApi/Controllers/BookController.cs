
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly DBContext _context;
        private IBookRepository booksRepository;

        public BookController(DBContext context, IBookRepository booksRepository)
        {
            this._context = context;
            this.booksRepository = booksRepository;
        }

        [HttpGet("getDbSize")]

        public int getDbSize()
        {
            return booksRepository.getDbSize();
        }

        [HttpGet("GetAll")]
        public Task<List<Books>> GetAll()
        {
            return booksRepository.GetAll();

        }

        [HttpGet("Borrow")]
        public void Borrow(int bookID,int userID)
        {
            booksRepository.Borrow(bookID,userID);
        }

        [HttpGet("Deliver")]
        public int Deliver(int bookID)
        {
            return booksRepository.Deliver(bookID);
        }

        [HttpGet("edit")]
        public void edit(String findBook, String name, DateTime releaseDate, DateTime createTime, int authorID, int genreID, String coverPhoto)
        {
            booksRepository.edit(findBook, name, releaseDate, createTime, authorID, genreID, coverPhoto);
        }

        [HttpGet("getBook")]
        public Books GetBook(int id)
        {
            return booksRepository.GetBook(id);
        }

        [HttpGet("assingRandomScores")]
        public async void assignRandomScores()
        {
            booksRepository.assignRandomScores();
        }

        [HttpGet("assingRandomPopularity")]
        public async void assignRandomPopularity()
        {
            booksRepository.assignRandomPopularity();
        }

        [HttpGet("sortScores")]
        public List<Books> sortScores()
        {
            return booksRepository.sortScores();
        }

        [HttpGet("remainingTime")]
        public int remaniningTime(int bookID)
        {
            return booksRepository.remaniningTime(bookID);

        }

        [HttpGet("checkCurrentPenalty")]
        public int checkCurrentPenalty(int bookID)
        {
            return booksRepository.checkCurrentPenalty(bookID);
        }

        [HttpGet("deleteSelected")]
        public async void DeleteSelected(int id)
        {
            booksRepository.DeleteSelected(id);
        }

        [HttpGet("findBookFromName")]
        public Books findBookFromName(String name)
        {
            return booksRepository.findBookFromName(name);
        }
    }
}
