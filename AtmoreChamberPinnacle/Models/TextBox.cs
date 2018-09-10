using System.ComponentModel.DataAnnotations;

namespace AtmoreChamberPinnacle.Models
{
    public class TextBox
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Paragraph { get; set; }

    }
}