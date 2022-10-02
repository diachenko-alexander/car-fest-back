namespace CarFest.BL.DTO
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public bool IsMainImage { get; set; }
        public byte[] ImageDate { get; set; }
        public int CarId { get; set; }
    }
}
