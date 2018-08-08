using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AtmoreChamber.Models
{
    [Table("Members")]
        
        public partial class Members
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