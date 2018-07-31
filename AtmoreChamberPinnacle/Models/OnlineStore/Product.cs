using System.ComponentModel.DataAnnotations;

namespace AtmoreChamberPinnacle.Models.OnlineStore
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string ProductType { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Is it in stock?")]
        public bool isInStock { get; set; }

        [Required]
        [Display(Name = "Amount in stock")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Picture")]
        public string imgSource { get; set; }

    }
}
