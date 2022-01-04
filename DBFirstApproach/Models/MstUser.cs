using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBFirstApproach.Models
{
    public partial class MstUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
        public int? TrainnerId { get; set; }
        public int? PlanId { get; set; }
        public int? Role { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TblPlan Plan { get; set; }
        public virtual MstTrainner Trainner { get; set; }
    }
}
