using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using TCRB.DAL.Model.Appsetting;
using TCRB.DAL.Model.Authentication;
using TCRB.DAL.Model.Commons;
using TCRB.DAL.UserManagement.EntityModel;

namespace TCRB.DAL.DataAccess.UserManagement
{
    public class UserManagementDataAccess : IUserManagementDataAccess
    {
        private readonly AppsittingModel _appsitting;
        private readonly UserManagementDBContext _context;
        private readonly IMapper _mapper;
        public UserManagementDataAccess(IOptions<AppsittingModel> appsitting, UserManagementDBContext context, IMapper mapper)
        {
            _appsitting = appsitting.Value;
            _context = context;
            _mapper = mapper;
        }

        public ResponseModel<ADUserModel> InquiryADUser(string adUser)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new ResponseModel<ADUserModel>();
            var adUserData = new ADUserModel();

            try
            {
                var emp = _context.Employee.Where(r => r.ADUser == adUser).FirstOrDefault();
                if (emp != null)
                {
                    //Employee
                    adUserData = _mapper.Map<ADUserModel>(emp);

                    //Permission in system
                    var _permissionsList = _context.Permission.Where(p => p.SystemID == _appsitting.SystemID).ToList();
                    var _permissionID = _permissionsList.Select(p => p.PermissionID).ToList();

                    //Group in employee
                    var _groups = (from g in _context.Group
                                   join gp in _context.GroupPermission.Where(r => _permissionID.Contains(r.PermissionID)) on g.GroupID equals gp.GroupID
                                   join gl in _context.GroupList.Where(r => r.EmpCode == emp.Emp_Code) on gp.GroupID equals gl.GroupID
                                   select new GroupADModel
                                   {
                                       GroupID = g.GroupID,
                                       TH_GroupName = g.TH_GroupName,
                                       ENG_GroupName = g.ENG_GroupName,
                                       Description = g.Description,
                                       CreateBy = g.CreateBy,
                                       CreateOn = g.CreateOn,
                                       UpdateBy = g.UpdateBy,
                                       UpdateOn = g.UpdateOn,
                                       PermissionID = gp.PermissionID
                                   }).ToList();


                    if (_groups != null && _groups.Any())
                    {
                        foreach (var g in _groups)
                        {
                            var _permissions = _permissionsList.Where(r => r.PermissionID == g.PermissionID).ToList();
                            g.Permissions.AddRange(_mapper.Map<List<PermissionADModel>>(_permissions));
                            adUserData.Permissions.AddRange(g.Permissions);
                        }
                        adUserData.Groups.AddRange(_groups);
                    }

                    result.Datas = adUserData;
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }

            return result;
        }
    }
}
