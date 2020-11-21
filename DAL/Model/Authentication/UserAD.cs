using System;
using System.Collections.Generic;
using TCRB.DAL.UserManagement.EntityModel;

namespace TCRB.DAL.Model.Authentication
{
    public class ADUserModel : Employee
    {
        public List<GroupADModel> Groups { get; set; } = new List<GroupADModel>();
        public List<PermissionADModel> Permissions { get; set; } = new List<PermissionADModel>();
    }

    public class GroupADModel : Group
    {
        public string PermissionID { get; set; }
        public List<PermissionADModel> Permissions { get; set; } = new List<PermissionADModel>();
    }

    public class PermissionADModel : Permission
    {
    }
}
