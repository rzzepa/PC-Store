using System.ComponentModel.DataAnnotations;

namespace PC_Store.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartitemId { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
