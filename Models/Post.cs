using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogVer2
{
    public class Post
    {
        public int Id{ get; set; }
        
        [Required]
        [DisplayName("תאריך פרסום")]
        public DateTime PublishDate { get; set; }
        
        [Required]
        [DisplayName("כותרת")]
        public string Title { get; set; }
                        
        [Required]
        [DisplayName("גוף הפוסט")]
        public string BodyText { get; set; } // with HTML tags

    }
}
