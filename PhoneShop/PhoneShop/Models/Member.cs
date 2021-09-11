using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Models
{
    public class Member
    {
        /// <summary>
        /// 會員ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 會員帳號
        /// </summary>
        [Required]
        public string UserId { get; set; }
        /// <summary>
        /// 會員密碼
        /// </summary>
        [Required]
        public string UserPassword { get; set; }
        /// <summary>
        /// 會員信箱
        /// </summary>
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
    }
}