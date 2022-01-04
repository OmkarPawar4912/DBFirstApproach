using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBFirstApproach.Models
{
    public partial class MstTrainner
    {
        public MstTrainner()
        {
            MstUser = new HashSet<MstUser>();
        }

        public int Id { get; set; }
        public string TrainnerName { get; set; }
        public int? Gender { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<MstUser> MstUser { get; set; }
    }
}
