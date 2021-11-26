using System.Linq;
using System.Threading.Tasks;
using DAL.DataAccess;

namespace DAL.DataWrapper
{
    public interface IDataAccessWrapper
    {
        IUserTestDataAccess UserTestDataAccess { get; }
    }
}
