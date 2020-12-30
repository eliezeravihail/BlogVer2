using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogVer2
{
    public class User
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        
        public ICollection<Post> Posts { get; set; }
              
        [Required]
        public string HashOfPassword { get; set; }


    }
}
