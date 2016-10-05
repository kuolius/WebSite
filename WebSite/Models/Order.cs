using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Attributes;

namespace WebSite.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        [Display(Name ="Card Number")]
        [StringLength(16, MinimumLength = 16,ErrorMessage ="Your debit card number is invalid.")]
        [RegularExpression(@"[0-9]*",ErrorMessage ="Only numbers are allowed.")]
        public string cardNumber { get; set; }

        [Required]
        [Display(Name ="First Name")]
        [MaxWords(1)]
        public string firstName { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Conf. your email")]
        [Compare("Email")]
        public string EmailConfirm { get; set; }
        
    }
}
