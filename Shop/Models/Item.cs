using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Item
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Category { get; set; }
        //public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? NumberAvailable { get; set; }
    }
}