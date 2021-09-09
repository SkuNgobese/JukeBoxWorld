using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JooBoxWorld.Models
{
    public class Voucher
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Voucher number")]
        public string VNumber { get; set; }

        [Range(5,2000,ErrorMessage ="No voucher for less than R{0}.00 and greater than R{1}.00")]
        [Display(Name = "Amount")]
        public double Amount { get; set; }

        [Display(Name = "Date")]
        public DateTime SellDate { get; set; }

        [Display(Name = "Used?")]
        public bool IsUsed { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
