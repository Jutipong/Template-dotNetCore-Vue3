using System;
using System.Collections.Generic;

namespace TCRB.DAL.Model.Authentication
{
    public class UserLoginModel
    {
        public string ADUser { get; set; }
        public DateTime BirthDate { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string DepartmentID { get; set; }
        public string Level { get; set; }
        public string EmpCode { get; set; }
        public string OfficerCode { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string Sex { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Active { get; set; }
        public List<PermissionModel> Permissions { get; set; } = new List<PermissionModel>();

    }

    public class PermissionModel
    {
        public string ID { get; set; }
        public string SystemID { get; set; }
        public string NameTh { get; set; }
        public string NameEng { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public class ClaimResponseModel
    {
        public string Sid { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string RoleName { get; set; }
        public string Spn { get; set; }

    }

    public class MenuModel
    {
        public string Controller { get; set; }
        public MenuItem Item { get; set; }
    }

    public class MenuAccess
    {
        public int Screenid { get; set; }
        public string Screenname { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }

    public class MenuItem
    {
        public List<string> Action { get; set; }
        public List<string> ScreenName { get; set; }
    }

    public class RolesPermissionModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    public class UserModel //For test.
    {
        public Guid ID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Last { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
