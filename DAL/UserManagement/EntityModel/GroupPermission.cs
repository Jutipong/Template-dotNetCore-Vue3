﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TCRB.DAL.UserManagement.EntityModel
{
    public partial class GroupPermission
    {
        [Key]
        public int GroupID { get; set; }
        public string PermissionID { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}