using System;
using System.ComponentModel.DataAnnotations;

namespace AtmoreChamber.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ThemeColor { get; set; }
        public bool IsFullDay { get; set; }

    }
}