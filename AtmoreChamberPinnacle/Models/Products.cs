using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AtmoreChamber.Models
{
    public class Products
    {

        [Key]
        public int ProductID { get; set; }

        [Required]
        [DisplayName("Name")]
        public string ProductTitle { get; set; }

        [DisplayName("Description")]
        public string ProductDescription { get; set; }

        [DisplayName("Image")]
        public byte[] ProductIMG { get; set; }

        [Required]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public float? ProductPrice { get; set; }

    }
}