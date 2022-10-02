using System.Collections.Generic;

namespace CarFest.DAL.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Image> Images { get; set; }

    }
}
