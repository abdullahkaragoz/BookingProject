namespace BookingProject.Domain.Entities
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
