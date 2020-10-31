using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using TCRB.BLL;
using TCRB.DAL.Entity;
using TCRB.DAL.Model.Authentication;
using TCRB.DAL.Model.Commons;
using TCRB.HELPER;
using TCRB.WEB.Models.UserTest;

namespace TCRB.WEB.Controllers
{
    [Authorize]
    public class UsertTestController : Controller
    {
        private readonly UserTestDataService _userTestDataService;
        private readonly UserLoginModel _userLogin;
        public UsertTestController(UserTestDataService userTestDataService, UserLogin userLogin)
        {
            _userTestDataService = userTestDataService;
            _userLogin = userLogin.UserProfile();
        }

        public IActionResult Index()
        {
            var model = new UserTestViewModel
            {
                IsActiveMaster = new List<SelectListItem>
                {
                new SelectListItem{ Value = EnumStatus.Active.AsDescription(), Text = EnumStatus.Active.ToString()},
                new SelectListItem{ Value = EnumStatus.Inactive.AsDescription(), Text = EnumStatus.Inactive.ToString()}
                },
                UserTest = new UserTest
                {
                    IsActive = EnumStatus.Active.AsDescription()
                }
            };
            return View(model);
        }

        public JsonResult InquiryMasterDatatable(DatableOption option, UserTest userTest)
        {
            var result = _userTestDataService.InquiryMasterDatatable(option, userTest);
            return Json(result);
        }

        public JsonResult Create(UserTest userTest)
        {
            userTest.CreateBy = _userLogin.EmpCode;
            userTest.CreateDate = DateTime.Now;
            var result = _userTestDataService.Create(userTest);
            return Json(result);
        }
        public JsonResult Update(UserTest userTest)
        {
            userTest.UpdateBy = _userLogin.EmpCode;
            userTest.UpdateDate = DateTime.Now;
            var result = _userTestDataService.Update(userTest);
            return Json(result);
        }
        public JsonResult Delete(UserTest userTest)
        {
            var result = _userTestDataService.Delete(userTest);
            return Json(result);
        }
    }
}
