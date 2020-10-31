using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.DataAccess;
using TCRB.DAL.DataAccess.UserManagement;

namespace TCRB.DAL.DataWrapper
{
    public interface IDataAccessWrapper
    {
        IUserManagementDataAccess UserManagementDataAccess { get; }
        IUserTestDataAccess UserTestDataAccess { get; }


        void SaveChanges();
        Task SaveChangesAsync();
        int Count<T>(IQueryable<T> query);
    }
}
