
namespace Library.Domain.Entities
{
    public class Books
    {
        public int id {  get; set; }
        public string? name { get; set; }
        public DateTime? releaseDate { get; set; }
        public DateTime? createTime { get; set; }
        public DateTime? updateTime { get; set; }
        public string? updater { get; set; }
        public bool? isDeleted { get; set; } = false;
        public int? authorID { get; set; }
        public int? genreID { get; set; }    
        public int? userID { get; set; }
        public bool isBorrowed { get; set; } = false;
        public DateTime? borrowDate { get; set; } = null;
        public String? coverPhoto { get; set; } = null;
        public int? score { get; set; }
        public int? popularity { get; set; }
        public string? review {  get; set; }

        public virtual Users? user { get; set; } // User object (1 user per book) foreign key
        public virtual Authors? author { get; set; } // Author object (1 author per book) foreign key
        public virtual Genres? genre { get; set; } // Genre object (1 genre per book) foreign key

    }
}
