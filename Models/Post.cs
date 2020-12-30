using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogVer2
{
    public class Post
    {
        public int ID { get; set; }
        
        [Required]
        public string PublishDate { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public ICollection<Tag> Tags{ get; set; }
        
        [Required]
        public User Writer { get; set; }
        
        [Required]
        public string BodyText { get; set; } // with HTML tags


    }
}
