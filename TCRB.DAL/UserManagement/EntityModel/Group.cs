using System;
using System.ComponentModel.DataAnnotations;

namespace TCRB.DAL.UserManagement.EntityModel
{
    public partial class Group
    {
        [Key]
        public int GroupID { get; set; }
        public string TH_GroupName { get; set; }
        public string ENG_GroupName { get; set; }
        public string Description { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}
