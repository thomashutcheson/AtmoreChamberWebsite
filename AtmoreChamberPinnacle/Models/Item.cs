namespace AtmoreChamber.Models
{
    public class Item
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public float TotalPrice { get { return Quantity * Product.ProductPrice; } }

    }
}