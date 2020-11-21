using System;
using System.ComponentModel.DataAnnotations;

namespace TCRB.DAL.UserManagement.EntityModel
{
    public partial class UserAD
    {
        [Key]
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string AdUser { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
