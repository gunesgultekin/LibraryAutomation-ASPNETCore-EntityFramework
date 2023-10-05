
using Library.Domain.Entities;

namespace Library.Application.Interfaces
{
    public interface IGenreRepository 
    {
        void Add(Genres entity);
        void Delete(Genres entity);
        void Update(Genres entity);
        public Genres getGenre(int id);
    }
}
