using System.ComponentModel.DataAnnotations;

namespace AtmoreChamberPinnacle.Models
{
    public class Paragraph
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

    }
}