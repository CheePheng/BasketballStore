using System.ComponentModel.DataAnnotations;

namespace BasketballStore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ImageUrl {  get; set; }
    }
}
