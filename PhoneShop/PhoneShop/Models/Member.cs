using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneShop.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
    }
}