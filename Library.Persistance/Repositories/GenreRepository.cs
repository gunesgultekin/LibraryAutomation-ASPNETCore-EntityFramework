
using Library.Domain.Entities;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{ 
    public class GenreRepository : IGenreRepository
    {
        private readonly DBContext _context;
        public GenreRepository(DBContext context)
        {
            _context = context;
        }
        public void Add(Genres entity)
        {
            //            
        }

        public Genres getGenre(int id)
        {
            var genre = _context.Genres.FirstOrDefault(g => g.id == id);
            return genre;
        }

        public void Delete(Genres entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Genres entity)
        {
            throw new NotImplementedException();
        }
    }
}
