using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WEB.Models.UserTest
{
    public class UserTestViewModel
    {
        public DAL.Entity.UserTest UserTest = new DAL.Entity.UserTest();
        public List<SelectListItem> IsActiveMaster = new List<SelectListItem>();
    }
}
