using Library.Domain.Entities;

namespace Library.Domain.Entities
{
    public class Users
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public bool? isDeleted { get; set; } = false;
        public int roleID { get; set; }
        public virtual List<Books>? BookList { get; set; }
        public virtual Roles? role { get; set; }
    }
}
