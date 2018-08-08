using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtmoreChamber.Models.OnlineStore
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        public IEnumerable<CartItem> CartItems { get; set;}

        public decimal TotalPrice {
            get {
                decimal total = 0;
                foreach (var item in CartItems)
                {
                    total += item.TotalPrice;
                }
                return total;
            }
        }

    }

    public class CartItem
    {
        [ForeignKey("CartId")]
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }


        public int Quantity { get; set; }

        public decimal TotalPrice { get { return Product.Price * Quantity; } }


    }
}
