using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BlogVer2.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string content { get; set; }

        [Required]
        [EmailAddress]
        public string mail { get; set; }

    }
}
