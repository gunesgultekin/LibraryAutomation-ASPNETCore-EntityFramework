
using Library.Domain.Entities;
using Library.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public class BooksRepository : IBookRepository
    {
        const int workingDays = 10;
        private readonly DBContext _context;
        public BooksRepository(DBContext context)
        {
            _context = context;
        }

        public void Add(Books entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Books entity)
        {
            if (entity == null)
                return;
            entity.isDeleted = true;
        }

        public void Update(Books entity)
        {
            _context.Books.Update(entity);
            _context.SaveChanges();
        }

        public async Task<List<Books>> GetAll()
        {         
            try
            {
                var books = await _context.Books
                    .AsNoTracking()
                .Include(b => b.author)
                .Include(b => b.genre)
                .Where(z => !z.isDeleted.Value)
                .ToListAsync();
                return books;
            }
            catch (Exception ex)
            {
                return new List<Books>();
            }
        }

        public async void AddBook(int id, string name, DateTime releaseDate, DateTime createDate
            , DateTime updateTime, string updater, bool isDeleted, int authorID, int genreID, int userID)
        {
            Books newBook = new()
            {
                name = name,
                releaseDate = releaseDate,
                createTime = createDate,
                updateTime = updateTime,
                updater = updater,
                isDeleted = isDeleted,
                authorID = authorID,
                genreID = genreID,
                userID = userID
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        public async void DeleteSelected(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.id == id);
            if (book == null) return;
            book.isDeleted = true;
            _context.SaveChanges();
        }

        public void Borrow(int bookID,int userID)
        {
            var book = _context.Books.FirstOrDefault(b => b.id == bookID && !b.isBorrowed);
            if (book == null) return;
            book.isBorrowed = true;
            book.userID = userID;            
            book.borrowDate = DateTime.Now;
            _context.SaveChanges();
        }

        public int Deliver(int bookID)
        {
            var book = _context.Books.FirstOrDefault(b => b.id == bookID);
            if (book == null) return -1;
            var a = Penalty(book);
            book.isBorrowed = false;
            book.borrowDate = null;
            book.userID = null;
            _context.SaveChanges();
            return a;
        }

        public int Penalty(Books book)
        {
            double multiplier = 0;
            var currentDateTime = DateTime.Now;
            DateTime limitDateTime = CalculateWorkDaysAfter(book.borrowDate.Value , workingDays);
            if (currentDateTime > limitDateTime) // DELAY STARTED
            {
                multiplier = (currentDateTime - limitDateTime).TotalDays;
                return (int)multiplier * 10;
            }
            return (int)multiplier * 10;
        }

        public DateTime CalculateWorkDaysAfter(DateTime currentDate, int workDays)
        {
            int daysToAdd = 0;
            int count = 0;
            while (count < workDays)
            {
                currentDate = currentDate.AddDays(1);
                // Check if the current day is a weekend (Saturday or Sunday)
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return currentDate;
        }

        public int getDbSize()
        {
            return _context.Books.Where(z => !z.isDeleted.Value).Count();
        }

        public void edit(String findBook,String? name, DateTime? releaseDate, DateTime? createTime, int? authorID, int? genreID, String? coverPhoto)
        {
            var book = _context.Books.FirstOrDefault(b => b.name == findBook);
            if (book!=null)
            {
                book.name = name;
                book.releaseDate = releaseDate;
                book.createTime = createTime;
                book.authorID = authorID;
                book.genreID = genreID;
                book.coverPhoto = coverPhoto;
                _context.SaveChanges();
            }
        }
        
        public Books GetBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.id == id);
            return book;
        }

        public void assignRandomScores()
        {
            Random random = new Random();
            List<Books> books = new List<Books>();
            books = _context.Books.ToList();
            for (int i=0;i<books.Count;++i)
            {
                books[i].score = random.Next(1,10);
            }
            _context.SaveChanges();
        }
        public void assignRandomPopularity()
        {
            Random random = new Random();
            List<Books> books = new List<Books>();
            books = _context.Books.ToList();
            for (int i=0;i<books.Count;++i)
            {
                books[i].popularity = random.Next(0,50000);
            }
            _context.SaveChanges();
        }

        public List<Books> sortScores()
        {
            List<Books> books = new List<Books>();
            books = _context.Books
                    .AsNoTracking()
                .Include(b => b.author)
                .Include(b => b.genre)
                .Where(z => !z.isDeleted.Value)
                .ToList();

            List<Books> topBooks = books;
            for (int i=0;i<topBooks.Count-1;++i)
            {
                for (int j=0;j<topBooks.Count-i-1;++j)
                {
                    if (topBooks[j].score > topBooks[j+1].score)
                    {
                        var temp = topBooks[j];
                        topBooks[j] = topBooks[j + 1];
                        topBooks[j + 1] = temp;                  
                    }
                }
            }
            topBooks.Reverse();
            return topBooks.GetRange(0,10);
        }

        public int  remaniningTime(int bookID)
        {
            var book = _context.Books.FirstOrDefault(b => b.id == bookID);
            DateTime timeLimit = CalculateWorkDaysAfter(book.borrowDate.Value,10);
            return (timeLimit - DateTime.Now).Days;
        }

        public int checkCurrentPenalty(int bookID)
        {
            var book = _context.Books.FirstOrDefault(b=> b.id == bookID);
            return Penalty(book);
        }

        public Books findBookFromName(String name)
        {
            var book = _context.Books.FirstOrDefault(b => b.name == name);
            return book;
        }
    }
}
