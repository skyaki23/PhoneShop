using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneShop.ViewModels
{
    public class RegisterMemberViewModel
    {
        [DisplayName("帳號")]
        [Required]
        public string UserId { get; set; }

        [DisplayName("密碼")]
        [Required]
        public string UserPassword { get; set; }

        [DisplayName("信箱")]
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
    }

    public class LoginMemberViewModel
    {
        [DisplayName("帳號")]
        public string UserId { get; set; }

        [DisplayName("密碼")]
        public string UserPassword { get; set; }   
    }
}