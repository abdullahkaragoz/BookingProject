namespace BookingProject.Domain.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public bool Status { get; set; }
        public List<Car> Cars { get; set; }
    }
}
