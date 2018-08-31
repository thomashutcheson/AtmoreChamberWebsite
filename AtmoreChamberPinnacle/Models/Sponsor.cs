using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace AtmoreChamberPinnacle.Models
{
    public class Sponsor
    {
        [Key]
        public int SponsorID { get; set; }

        [Required]
        [DisplayName("Name of Sponsor")]
        public string SponsorName { get; set; }

        [Required]
        [DisplayName("Sponsor Details")]
        public string SponsorDescription { get; set; }

        [Required]
        [DisplayName("Sponsor's Website address")]
        public string SponsorLink { get; set; }

        [Required]
        [DisplayName("Upload Image")]
        public string SponsorImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }





    }
}