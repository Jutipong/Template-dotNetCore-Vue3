using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TCRB.DAL.Model.Appsetting;

namespace TCRB.DAL
{
    public class TCRBDBContext : DBContext.DBContext
    {
        private readonly AppsittingModel _configuration;

        public TCRBDBContext(IOptions<AppsittingModel> configuration)
        {
            _configuration = configuration.Value;
        }

        public TCRBDBContext(DbContextOptions<DBContext.DBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.ConnectionStrings.TCRBDB);
            }
        }
    }

    public class UserManagementDBContext : UserManagement.DBContext.UserManagementContext
    {
        private readonly AppsittingModel _configuration;

        public UserManagementDBContext(IOptions<AppsittingModel> configuration)
        {
            _configuration = configuration.Value;
        }

        public UserManagementDBContext(DbContextOptions<UserManagement.DBContext.UserManagementContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.ConnectionStrings.UserManagement);
            }
        }
    }
}
