
using Library.Domain.Entities;
using Library.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DBContext _context;

        public UsersRepository(DBContext context)
        {
            _context = context;
        }

        public void Add(Users entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Users userID)
        {
            userID.isDeleted = true;
        }
             
        public Users  GetUserInfo(String userName)
        {
            var user = _context.Users
                .AsNoTracking()
                .Include(u => u.role)
                .Include(u => u.BookList).ThenInclude(x => x.author)
                .Include(u => u.BookList).ThenInclude(x => x.genre)
                .FirstOrDefault(u=> u.username == userName);
         
            return user;
            
        }

        public void Update(Users entity)
        {
            throw new NotImplementedException();
        }

        public bool LoginAuth(string username, string password) 
        {
            var a = _context.Users.FirstOrDefault(u => u.username == username && u.password == password);
            if(a==null)
                return false; // NO LOGIN

            return true; // LOGIN

            
            

            






        }

        public int Register(string username, string password, string name, string surname)
        {

            int code;
            Users user = new Users();
            user.username = username;
            user.password = password;
            user.name = name;
            user.surname = surname;

            try
            {
                _context.Users.Add(user);
                code = 1; // REGISTER SUCCESSFUL
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                code = -1; // REGISTER ERROR
                
            }
            
            return  code;
            


        }
    }
}
