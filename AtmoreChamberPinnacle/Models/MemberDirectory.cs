using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AtmoreChamber.Models
{
    [Table("Member Directory")]
    public partial class MemberDirectory
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Business { get; set; }
        [StringLength(255)]
        public string BusinessAddress { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(75)]
        public string Website { get; set; }
        [StringLength(75)]
        public string Industry { get; set; }
    }
}
