using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.DataAccess;
using TCRB.DAL.DataAccess.UserManagement;
using TCRB.DAL.Model.Appsetting;

namespace TCRB.DAL.DataWrapper
{
    public class DataAccessWrapper : IDataAccessWrapper
    {
        private readonly TCRBDBContext _context;
        private readonly UserManagementDBContext _contextUserManagement;
        private readonly IOptions<AppsittingModel> _appsitting;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IMapper _mapper;

        private IUserManagementDataAccess _userManagementDataAccess;
        private IUserTestDataAccess _userTestDataAccess;

        public DataAccessWrapper(TCRBDBContext context, UserManagementDBContext contextUserManagement, IOptions<AppsittingModel> appsitting, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _context = context;
            _contextUserManagement = contextUserManagement;
            _appsitting = appsitting;
            _mapper = mapper;
            _loggerFactory = loggerFactory;
        }

        public IUserManagementDataAccess UserManagementDataAccess => _userManagementDataAccess ??= new UserManagementDataAccess(_appsitting, _contextUserManagement, _mapper);
        public IUserTestDataAccess UserTestDataAccess => _userTestDataAccess ??= new UserTestDataAccess(_context, _mapper);

        public void SaveChanges() => _context.SaveChanges();
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        public int Count<T>(IQueryable<T> query)
        {
            return query.Count();
        }
    }
}
