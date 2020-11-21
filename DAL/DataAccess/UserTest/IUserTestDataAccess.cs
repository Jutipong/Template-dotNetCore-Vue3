using DAL.Model.Commons;

namespace DAL.DataAccess
{
    public interface IUserTestDataAccess
    {
        DataTableResponseModel InquiryMasterDatatable(DatableOption option, Entity.UserTest userTest);
        ResponseModels<Entity.UserTest> Inquiry(Entity.UserTest userTest);
        ResponseModel Create(Entity.UserTest userTest);
        ResponseModel Update(Entity.UserTest userTest);
        ResponseModel Delete(Entity.UserTest userTest);
    }
}
