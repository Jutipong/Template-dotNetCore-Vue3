using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TCRB.DAL.Model.Commons;
using TCRB.HELPER;

namespace TCRB.DAL.DataAccess
{
    public class UserTestDataAccess : IUserTestDataAccess
    {
        public DataTableResponseModel InquiryMasterDatatable(DatableOption option, Entity.UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new DataTableResponseModel();

            try
            {
                var users = new List<Entity.UserTest>();
                users.Add(new Entity.UserTest { ID = Guid.NewGuid(), Name = "Name 1", Last = "Last 1", CreateBy = "CreateBy 1", CreateDate = DateTime.Now, IsActive = EnumStatus.Active.AsDescription() });
                users.Add(new Entity.UserTest { ID = Guid.NewGuid(), Name = "Name 2", Last = "Last 2", CreateBy = "CreateBy 2", CreateDate = DateTime.Now, IsActive = EnumStatus.Active.AsDescription() });
                users.Add(new Entity.UserTest { ID = Guid.NewGuid(), Name = "Name 3", Last = "Last 3", CreateBy = "CreateBy 3", CreateDate = DateTime.Now, IsActive = EnumStatus.Active.AsDescription() });
                users.Add(new Entity.UserTest { ID = Guid.NewGuid(), Name = "Name 4", Last = "Last 4", CreateBy = "CreateBy 4", CreateDate = DateTime.Now, IsActive = EnumStatus.Active.AsDescription() });
                users.Add(new Entity.UserTest { ID = Guid.NewGuid(), Name = "Name 5", Last = "Last 5", CreateBy = "CreateBy 5", CreateDate = DateTime.Now, IsActive = EnumStatus.Active.AsDescription() });
                users.Add(new Entity.UserTest { ID = Guid.NewGuid(), Name = "Name 6", Last = "Last 6", CreateBy = "CreateBy 6", CreateDate = DateTime.Now, IsActive = EnumStatus.Active.AsDescription() });
                users.Add(new Entity.UserTest { ID = Guid.NewGuid(), Name = "Name 7", Last = "Last 7", CreateBy = "CreateBy 7", CreateDate = DateTime.Now, IsActive = EnumStatus.Active.AsDescription() });
                users.Add(new Entity.UserTest { ID = Guid.NewGuid(), Name = "Name 8", Last = "Last 8", CreateBy = "CreateBy 8", CreateDate = DateTime.Now, IsActive = EnumStatus.Active.AsDescription() });

                var datas = users.ToList();
                var recordsTotal = datas.Count();

                result = new DataTableResponseModel
                {
                    status = true,
                    message = "success",
                    data = datas,
                    draw = option.draw,
                    recordsTotal = recordsTotal,
                    recordsFiltered = recordsTotal
                };

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }

            return result;
        }

        public ResponseModels<Entity.UserTest> Inquiry(Entity.UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new ResponseModels<Entity.UserTest>();

            try
            {
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }

            return result;
        }

        public ResponseModel Create(Entity.UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new ResponseModel();

            try
            {
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }

            return result;
        }

        public ResponseModel Update(Entity.UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new ResponseModel();

            try
            {
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }

            return result;
        }

        public ResponseModel Delete(Entity.UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new ResponseModel();

            try
            {
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }
            return result;
        }
    }
}
