using Library.Domain.Entities;

namespace Library.Domain.Entities
{
    public class Authors
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public bool? isDeleted { get; set; }
        public string? photo {  get; set; }
        public string? about { get; set; }

        public virtual List<Books>? BookList
        {
            get; set;
        }
    }
}
