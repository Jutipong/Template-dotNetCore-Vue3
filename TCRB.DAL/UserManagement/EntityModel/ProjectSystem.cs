using System;
using System.ComponentModel.DataAnnotations;

namespace TCRB.DAL.UserManagement.EntityModel
{
    public partial class ProjectSystem
    {
        [Key]
        public string SystemID { get; set; }
        public string TH_SystemName { get; set; }
        public string ENG_SystemName { get; set; }
        public string Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}
