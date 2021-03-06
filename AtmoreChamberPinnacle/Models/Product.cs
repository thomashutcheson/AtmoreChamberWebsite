﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace AtmoreChamber.Models
{
    public class Product
    {

        [Key]
        public int ProductID { get; set; }

        [Required]
        [DisplayName("Name")]
        public string ProductTitle { get; set; }

        [DisplayName("Description")]
        public string ProductDescription { get; set; }

        [DisplayName("Upload Image")]
        public string ImagePath { get; set; }

        [Required]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public float ProductPrice { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}