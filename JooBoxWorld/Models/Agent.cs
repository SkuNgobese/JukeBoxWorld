using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JooBoxWorld.Models
{
    public class Agent
    {
        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual FieldManager FieldManager { get; set; }
    }
}
