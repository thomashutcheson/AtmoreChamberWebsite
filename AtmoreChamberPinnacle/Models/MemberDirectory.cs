using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace AtmoreChamberPinnacle.Model
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
