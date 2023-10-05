using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IAuthorRepository
    {
        public void Add(Authors entity);
        public void Delete(Authors book);
        public void Update(Authors entity);
        public Task<List<Authors>> GetAll();
        public Authors getAuthorInfo(int authorID);       
    }
}
