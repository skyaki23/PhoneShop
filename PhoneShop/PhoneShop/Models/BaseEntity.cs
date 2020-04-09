using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneShop.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }

        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }
    }
}