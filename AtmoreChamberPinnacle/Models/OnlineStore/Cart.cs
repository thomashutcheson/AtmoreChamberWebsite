using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtmoreChamberPinnacle.Models.OnlineStore
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }


        public int Quantity { get; set; }


    }
}
