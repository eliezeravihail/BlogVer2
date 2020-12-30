using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogVer2
{
    public class Tag
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
