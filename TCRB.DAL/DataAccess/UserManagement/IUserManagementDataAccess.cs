using System;
using System.Collections.Generic;
using System.Text;
using TCRB.DAL.Model.Authentication;
using TCRB.DAL.Model.Commons;
using TCRB.DAL.UserManagement.EntityModel;

namespace TCRB.DAL.DataAccess.UserManagement
{
    public interface IUserManagementDataAccess
    {
        ResponseModel<ADUserModel> InquiryADUser(string adUser);
    }
}
