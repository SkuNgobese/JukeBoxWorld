using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JooBoxWorld.Models
{
    public class FieldManager
    {
        public FieldManager()
        {
            Agents = new List<Agent>();
        }
        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Display(Name = "Credit amount")]
        public double Amount { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Agent> Agents { get; set; }
    }
}
