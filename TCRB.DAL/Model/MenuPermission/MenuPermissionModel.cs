using System;
using System.Collections.Generic;
using System.Text;

namespace TCRB.DAL.Model.MenuPermission
{
    public class MenuPermissionModel
    {
        public List<MenuGroupModel> MenuGroups { get; set; } = new List<MenuGroupModel>();
    }

    public class MsMenusModel
    {
        public List<MenuGroupModel> MenuGroup { get; set; } = new List<MenuGroupModel>();
        public List<MenuModel> Menus { get; set; } = new List<MenuModel>();
    }

    public class MenuGroupModel
    {
        public string ID { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }

        public List<MenuModel> Menus { get; set; } = new List<MenuModel>();
    }

    public class MenuModel
    {
        public string ID { get; set; }
        public string MenuGroupID { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }

    public class PermissionModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<string> MenuIDs { get; set; } = new List<string>();
    }
}
