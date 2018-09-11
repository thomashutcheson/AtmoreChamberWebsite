using System.ComponentModel.DataAnnotations;

namespace AtmoreChamberPinnacle.Models
{
    public class Paragraph
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Link { get; set; }

        public string Subtitle { get; set; }

        [Required]
        public string Text { get; set; }

    }
}