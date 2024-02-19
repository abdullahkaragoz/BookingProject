using System.ComponentModel.DataAnnotations.Schema;

namespace BookingProject.Domain.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public int ReviewScore { get; set; }
        public string Comment { get; set; }

        [Column("Date")]
        public DateTime ReviewDate { get; set; }
    }
}
