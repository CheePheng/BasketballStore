using System.ComponentModel.DataAnnotations;

namespace BasketballStore.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public String CartId { get; set; }

        public Product Product { get; set; }
    }
}
