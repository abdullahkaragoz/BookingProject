using System.ComponentModel.DataAnnotations.Schema;

namespace BookingProject.Domain.Entities
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string Title { get; set; }

        [Column("Date")]
        public DateTime CreatedDate { get; set; }
        public string CoverImage { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
