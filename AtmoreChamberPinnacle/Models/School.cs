using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AtmoreChamberPinnacle.Models
{
    public class School
    {

        [Key]
        public int SchoolID { get; set; }

        [Required]
        [DisplayName("Name of School")]
        public string SchoolName { get; set; }

        [Required]
        [DisplayName("Type of School")]
        public int SchoolTypeID { get; set; }

        [Required]
        [DisplayName("Link to Website")]
        public string SchoolWebsite { get; set; }


    }
}