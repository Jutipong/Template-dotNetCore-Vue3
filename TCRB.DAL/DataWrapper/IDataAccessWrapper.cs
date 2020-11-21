using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.DataAccess;

namespace TCRB.DAL.DataWrapper
{
    public interface IDataAccessWrapper
    {
        IUserTestDataAccess UserTestDataAccess { get; }
    }
}
