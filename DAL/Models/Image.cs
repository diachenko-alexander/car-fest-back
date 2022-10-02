namespace CarFest.DAL.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public bool IsMainImage { get; set; }
        public byte[] ImageDate { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
