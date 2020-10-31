using System;
using System.ComponentModel.DataAnnotations;

namespace TCRB.DAL.UserManagement.EntityModel
{
    public partial class Department
    {
        [Key]
        public string DepartmentID { get; set; }
        public string TH_DepartmentName { get; set; }
        public string ENG_DepartmentName { get; set; }
        public string ParentNode { get; set; }
        public byte? Level { get; set; }
        public string Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}
