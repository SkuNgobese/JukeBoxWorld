using JooBoxWorld.Models;
using JooBoxWorld.Models.Validations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JooBoxWorld.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Vouchers = new List<Voucher>();
        }
        public byte[] Avi { get; set; }

        [PersonalData]
        public string Title { get; set; }

        [PersonalData]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [PersonalData]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string FullName { get { return Title + " " + FirstName + " " + MiddleName + " " + LastName; } }

        [PersonalData]
        [Display(Name = "ID number")]
        public string IdNo { get; set; }

        [PersonalData]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        [PersonalData]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Address Address { get; set; }
        public virtual FieldManager FieldManager { get; set; }
        public virtual Agent Agent { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
