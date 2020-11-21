using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.DataAccess;
using TCRB.DAL.Model.Appsetting;

namespace TCRB.DAL.DataWrapper
{
    public class DataAccessWrapper : IDataAccessWrapper
    {
        private readonly IOptions<AppsittingModel> _appsitting;

        private IUserTestDataAccess _userTestDataAccess;

        public DataAccessWrapper(IOptions<AppsittingModel> appsitting, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _appsitting = appsitting;
        }

        public IUserTestDataAccess UserTestDataAccess => _userTestDataAccess ??= new UserTestDataAccess();
    }
}
