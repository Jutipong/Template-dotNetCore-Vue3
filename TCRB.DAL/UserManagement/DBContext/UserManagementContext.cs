using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TCRB.DAL.UserManagement.EntityModel;

namespace TCRB.DAL.UserManagement.DBContext
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext()
        {
        }
        public UserManagementContext(DbContextOptions<UserManagementContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<GroupList> GroupList { get; set; }
        public virtual DbSet<GroupPermission> GroupPermission { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<ProjectSystem> ProjectSystem { get; set; }
        public virtual DbSet<UserAD> UserAD { get; set; }
    }
}
