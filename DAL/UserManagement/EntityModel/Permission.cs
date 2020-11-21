using System;
using System.ComponentModel.DataAnnotations;

namespace TCRB.DAL.UserManagement.EntityModel
{
    public partial class Permission
    {
        [Key]
        public string PermissionID { get; set; }
        public string SystemID { get; set; }
        public string TH_PermissionName { get; set; }
        public string ENG_PermissionName { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}
