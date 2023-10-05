
using Library.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Interfaces
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DBContext _context;

        public AuthorRepository(DBContext context)
        {
            _context = context;
        }

        public Authors getAuthorInfo(int authorID)
        {
            var author = _context.Authors.FirstOrDefault(a => a.id == authorID);
            return author;
        }

        public void Add(Authors entity)
        {
            _context.Authors.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Authors entity)
        {
            entity.isDeleted = true;
            _context.SaveChanges();
        }

        public Task<List<Authors>> GetAll()
        {
            var authors = _context.Authors.ToListAsync();
            return authors;    
        }

        public void Update(Authors entity)
        {
            _context.Authors.Update(entity);
            
        }      
    }
}
