using JooBoxWorld.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JooBoxWorld.Models
{
    public class Address
    {
        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Street address cannot contain special characters")]
        [Display(Name = "Street", Prompt = "385 Jorissen St")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "{0} cannot contain numbers or special characters")]
        [Display(Name = "Suburb", Prompt = "Faerie Glen")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "Please enter {0}")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "{0} cannot contain numbers or special characters")]
        [Display(Name = "City", Prompt = "Pretoria")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Postal Code")]
        [StringLength(4, ErrorMessage = "Postal Code is 4 digits long", MinimumLength = 4)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "{0} cannot contain letter or special characters")]
        [Display(Name = "Code", Prompt = "0002")]
        public string Code { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
