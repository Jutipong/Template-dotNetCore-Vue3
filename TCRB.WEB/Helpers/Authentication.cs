using Microsoft.Extensions.Options;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel;
using System.Threading.Tasks;
using TCRB.DAL.Model.Appsetting;
using TCRB.DAL.Model.Authentication;
using TCRB.DAL.Model.Commons;
using TCRB.DAL.Model.UserLogin;

namespace TCRB.WEB.Helpers
{
    public class Authentication
    {
        private readonly AppsittingModel _appsitting;

        public Authentication(IOptions<AppsittingModel> appsitting)
        {
            _appsitting = appsitting.Value;
        }

        public async Task<ResponseModel<UserLoginModel>> WebserviceAsync(LoginModel login)
        {
            var result = new ResponseModel<UserLoginModel>();
            try
            {
                CheckUserloginResponse userlogin;

                BasicHttpBinding basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.None);
                basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

                using (var soapClient = new UserManagementSoapClient(basicHttpBinding, new EndpointAddress(_appsitting.EndpointAddress.UserManagementService)))
                {
                    userlogin = await soapClient.CheckUserloginAsync(login.UserName, login.Password,
                       new PreRequest
                       {
                           ADUser = "",
                           SystemID = _appsitting.SystemID,
                           Description = "",

                       });
                }

                if (!userlogin.Body.CheckUserloginResult.Message.IsSuccess)
                {
                    result.Message = userlogin.Body.CheckUserloginResult.Message.Message;
                }
                else
                {
                    var emp = userlogin.Body.CheckUserloginResult.Employee;
                    var UserProfile = new UserLoginModel
                    {
                        ADUser = emp.ADUser,
                        BirthDate = emp.BirthDate,
                        BranchCode = emp.BranchCode,
                        BranchName = emp.BranchName,
                        DepartmentID = emp.DepartmentID,
                        Level = emp.Level,
                        EmpCode = emp.Emp_Code,
                        OfficerCode = emp.OfficerCode,
                        PositionCode = emp.PositionCode,
                        PositionName = emp.PositionName,
                        Sex = emp.SEX,
                        NameTh = emp.TH_Name,
                        NameEn = emp.ENG_Name,
                        Telephone = emp.Telephone,
                        Email = emp.Email,
                        Active = emp.Active,
                    };

                    var permissions = new List<PermissionModel>();
                    emp.Groups.Select(r => r.Permissions).ToList().ForEach(groups =>
                    {
                        groups.ToList().ForEach(item =>
                        {
                            permissions.Add(new PermissionModel
                            {
                                ID = item.PermissionID,
                                SystemID = item.SystemID,
                                NameTh = item.TH_PermissionName,
                                NameEng = item.ENG_PermissionName,
                                CreateBy = item.CreateBy,
                                CreateDate = item.CreateOn,
                                UpdateBy = item.UpdateBy,
                                UpdateDate = item.UpdateOn
                            });
                        });
                    });
                    UserProfile.Permissions.AddRange(permissions);

                    result.Success = true;
                    result.Datas = UserProfile;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public ResponseModel AuthAs400(LoginModel login)
        {
            var result = new ResponseModel();
            try
            {
                var Connection = new OleDbConnection($"Provider={_appsitting.AS400Sitting.Provider}.DataSource.1;Data " +
                    $"Source={_appsitting.AS400Sitting.LibIP};" +
                    $"Password={login.Password};User ID={login.UserName};" +
                    $"Connect Timeout={_appsitting.AS400Sitting.Timeout}");
                Connection.Open();
                Connection.Close();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Login fail.";
                result.Code = ex.Message;
            }
            return result;
        }
    }
}
