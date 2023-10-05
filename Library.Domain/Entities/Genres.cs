
namespace Library.Domain.Entities
{
    public class Genres
    {
        public int id { get; set; }
        public string? name { get;set; }
        public bool? isDeleted { get;set; }
        public virtual List<Books>? BookList
        {
            get; set;
        }
    }
}
