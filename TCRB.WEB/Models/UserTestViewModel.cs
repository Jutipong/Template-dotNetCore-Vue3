using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TCRB.WEB.Models.UserTest
{
    public class UserTestViewModel
    {
        //Datas
        public DAL.Entity.UserTest UserTest = new DAL.Entity.UserTest();

        //Master
        public List<SelectListItem> IsActiveMaster = new List<SelectListItem>();
    }
}
