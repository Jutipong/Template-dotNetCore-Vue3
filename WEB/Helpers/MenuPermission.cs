using DAL.Model.Authentication;
using DAL.Model.MenuPermission;
using HELPER;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WEB.Helpers
{
    //รอย้ายไปลง DB
    public class MenuPermission
    {
        private readonly UserLoginModel _userProfile;

        public MenuPermission(UserLogin userLogin)
        {
            _userProfile = userLogin.UserProfile();
        }

        public MenuPermissionModel GetMenuPermission()
        {
            var result = new MenuPermissionModel();
            var menuInPermission = MsPremission(_userProfile.Permissions.Select(r => r.ID).ToList());
            var msMenus = MsMenus();
            //get menu sub
            var menuSub = msMenus.Menus.Where(r => menuInPermission.Contains(r.ID)).ToList();
            //get menu root
            msMenus.MenuGroup.Where(g => menuSub.Select(r => r.MenuGroupID).Contains(g.ID)).OrderBy(r => r.Order).ToList()
                .ForEach(menuGroup =>
                {
                    menuGroup.Menus.AddRange(menuSub.Where(s => s.MenuGroupID == menuGroup.ID));
                    result.MenuGroups.Add(menuGroup);
                });

            return result;
        }

        public MsMenusModel MsMenus()
        {
            var menuGroups = new List<MenuGroupModel>
            {
                new MenuGroupModel { ID = "M001", Order = 1, Name = "Customer", Icon = "fa fa-user-circle", IsActive = true },
                new MenuGroupModel { ID = "M002", Order = 2, Name = "Maintain Parameter", Icon = "fa fa-gears", IsActive = true }
            };
            var menus = new List<MenuModel>
            {
                //M001
                new MenuModel{ MenuGroupID = "M001", ID = "MS001", Order = 1,  Name = "Verify", Controller = "VerifyCustomer", Action = "Index", Icon = "fa fa-check", IsActive = true},
                new MenuModel{ MenuGroupID = "M001", ID = "MS002", Order = 2,  Name = "Inquiry", Controller = "InquiryCustomer", Action = "Index", Icon = "fa fa-search", IsActive = true},
                new MenuModel{ MenuGroupID = "M001", ID = "MS003", Order = 3,  Name = "Report", Controller = "Report", Action = "Index", Icon = "fa fa-search", IsActive = true},
                //M002
                new MenuModel{ MenuGroupID = "M002", ID = "MS004", Order = 1,  Name = "Question", Controller = "MsQuestion", Action = "Index", Icon = "fa fa-question", IsActive = true},
                new MenuModel{ MenuGroupID = "M002", ID = "MS005", Order = 2,  Name = "EndCallReason", Controller = "MsEndCallReason", Action = "Index", Icon = "fa fa-volume-control-phone", IsActive = true},
                new MenuModel{ MenuGroupID = "M002", ID = "MS006", Order = 3,  Name = "ConfigRule", Controller = "ConfigWrongAnswer", Action = "Index", Icon = "fa fa-terminal", IsActive = true},
                new MenuModel{ MenuGroupID = "M002", ID = "MS007", Order = 3,  Name = "ConfigOTP", Controller = "ConfigOTP", Action = "Index", Icon = "fa fa-commenting-o", IsActive = true},
                new MenuModel{ MenuGroupID = "M002", ID = "MS008", Order = 3,  Name = "Channel", Controller = "MsChannel", Action = "Index", Icon = "fa fa-columns", IsActive = true},
                new MenuModel{ MenuGroupID = "M002", ID = "MS009", Order = 3,  Name = "Level", Controller = "MsLevel", Action = "Index", Icon = "fa fa-level-up", IsActive = true},
                //new MenuModel{ MenuGroupID = "M002", ID = "MS010", Order = 3,  Name = "Reason", Controller = "MsVerificationReason", Action = "Index", Icon = "fa fa-check", IsActive = true},
                new MenuModel{ MenuGroupID = "M002", ID = "MS011", Order = 3,  Name = "VerifyType", Controller = "MsVerifyType", Action = "Index", Icon = "fa fa-check-circle", IsActive = true},
                new MenuModel{ MenuGroupID = "M002", ID = "MS012", Order = 3,  Name = "CustomerType", Controller = "MsCustomerType", Action = "Index", Icon = "fa fa-user", IsActive = true},
                new MenuModel{ MenuGroupID = "M002", ID = "MS013", Order = 3,  Name = "TopicType", Controller = "MsTopicType", Action = "Index", Icon = "fa fa-info", IsActive = true},
                new MenuModel{ MenuGroupID = "M002", ID = "MS014", Order = 3,  Name = "ServiceType", Controller = "MsServiceType", Action = "Index", Icon = "fa fa-server", IsActive = true},
                new MenuModel{ MenuGroupID = "M002", ID = "MS015", Order = 3,  Name = "ProductType", Controller = "MsProductType", Action = "Index", Icon = "fa fa-product-hunt", IsActive = true},
            };

            var result = new MsMenusModel();
            result.MenuGroup.AddRange(menuGroups);
            result.Menus.AddRange(menus);
            return result;
        }

        public List<string> MsPremission(List<string> permissions)
        {
            var InboundAgent = new DAL.Model.MenuPermission.PermissionModel
            {
                ID = EnumPermission.InboundAgent.AsDescription(),
                Name = EnumPermission.InboundAgent.ToString(),
                MenuIDs = new List<string> { "MS001", "MS002" }
            };
            var InboundSupervisor = new DAL.Model.MenuPermission.PermissionModel
            {
                ID = EnumPermission.InboundSupervisor.AsDescription(),
                Name = EnumPermission.InboundSupervisor.ToString(),
                MenuIDs = new List<string> { "MS001", "MS002", "MS003" }
            };
            var ChatAgent = new DAL.Model.MenuPermission.PermissionModel
            {
                ID = EnumPermission.ChatAgent.AsDescription(),
                Name = EnumPermission.ChatAgent.ToString(),
                MenuIDs = new List<string> { "MS001", "MS002" }
            };
            var ChatSupervisor = new DAL.Model.MenuPermission.PermissionModel
            {
                ID = EnumPermission.ChatSupervisor.AsDescription(),
                Name = EnumPermission.ChatSupervisor.ToString(),
                MenuIDs = new List<string> { "MS001", "MS002", "MS003" }
            };
            var BackOffice = new DAL.Model.MenuPermission.PermissionModel
            {
                ID = EnumPermission.BackOffice.AsDescription(),
                Name = EnumPermission.BackOffice.ToString(),
                MenuIDs = new List<string> { "MS001", "MS002" }
            };
            var BusinessAdmin = new DAL.Model.MenuPermission.PermissionModel
            {
                ID = EnumPermission.BusinessAdmin.AsDescription(),
                Name = EnumPermission.BusinessAdmin.ToString(),
                MenuIDs = new List<string> { "MS003", "MS004", "MS005", "MS006", "MS007", "MS008", "MS009", "MS010", "MS011", "MS012", "MS013", "MS014", "MS015" }
            };
            var QA = new DAL.Model.MenuPermission.PermissionModel
            {
                ID = EnumPermission.QA.AsDescription(),
                Name = EnumPermission.QA.ToString(),
                MenuIDs = new List<string> { "MS002" }
            };
            var Fraud = new DAL.Model.MenuPermission.PermissionModel
            {
                ID = EnumPermission.Fraud.AsDescription(),
                Name = EnumPermission.Fraud.ToString(),
                MenuIDs = new List<string> { "MS003" }
            };

            var result = new List<DAL.Model.MenuPermission.PermissionModel>
            {
                InboundAgent,
                InboundSupervisor,
                ChatAgent,
                ChatSupervisor,
                BackOffice,
                BusinessAdmin,
                QA,
                Fraud
            };

            var menus = new List<string>();
            result.Where(r => permissions.Contains(r.ID)).ToList().ForEach(r =>
            {
                menus.AddRange(r.MenuIDs);
            });

            return menus.Distinct().ToList();
        }

        public bool VerifyPermissionPage(string action, string controller)
        {
            var permissionPages = new List<MenuModel>();
            GetMenuPermission().MenuGroups.ForEach(r => { permissionPages.AddRange(r.Menus.ToList()); });
            var result = permissionPages.Any(r => r.Action.ToUpper() == action.ToUpper() && r.Controller.ToUpper() == controller.ToUpper());
            return result;
        }
    }
}
