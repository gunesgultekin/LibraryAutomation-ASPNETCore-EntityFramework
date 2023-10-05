using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IBookRepository 
    {
        public int getDbSize();
        public void Add(Books entity);
        public void Delete(Books book);
        public void Update(Books entity);
        public Task<List<Books>> GetAll();
        public void AddBook(int id, string name, DateTime releaseDate, DateTime createDate
            , DateTime updateTime, string updater, bool isDeleted, int authorID, int genreID, int userID); //
        public void DeleteSelected(int id);
        public void Borrow(int bookID,int userID);
        public int Deliver(int bookID);
        public int Penalty(Books book);

        public void edit(String findBook,String? name, DateTime? releaseDate, DateTime? createTime,int? authorID,int? genre,String? coverPhoto);

        public Books GetBook(int id);
        public void assignRandomScores();
        public void assignRandomPopularity();
        public List<Books> sortScores();
        public int remaniningTime(int bookID);
        public int checkCurrentPenalty(int bookID);
        public Books findBookFromName(String name);
    }
}
