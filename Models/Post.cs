using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogVer2
{
    public class Post
    {
        public int Id{ get; set; }
        
        [Required]
        public DateTime PublishDate { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        public ICollection<Tag> Tags{ get; set; }
        
        [Required]
        public User Writer { get; set; }
        
        [Required]
        public string BodyText { get; set; } // with HTML tags


    }
}
