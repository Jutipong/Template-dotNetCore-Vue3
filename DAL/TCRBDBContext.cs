using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DAL.Model.Appsetting;

namespace DAL
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
}
