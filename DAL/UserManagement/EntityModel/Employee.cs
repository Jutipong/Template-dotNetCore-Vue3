using System;
using System.ComponentModel.DataAnnotations;

namespace TCRB.DAL.UserManagement.EntityModel
{
    public partial class Employee
    {
        [Key]
        public string Emp_Code { get; set; }
        public string ADUser { get; set; }
        public byte[] UserImage { get; set; }
        public string IDNumber { get; set; }
        public string TH_Name { get; set; }
        public string ENG_Name { get; set; }
        public string NickName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string Level { get; set; }
        public string SEX { get; set; }
        public string Telephone { get; set; }
        public string NodeID { get; set; }
        public string NodeName { get; set; }
        public string DepartmentID { get; set; }
        public string BranchCode { get; set; }
        public string Email { get; set; }
        public string OfficerCode { get; set; }
        public DateTime? StartWorkDate { get; set; }
        public DateTime? ExpriedWorkDate { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public string Active { get; set; }
    }
}
