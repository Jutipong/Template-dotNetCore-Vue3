using BLL;
using DAL.Entity;
using DAL.Model.Commons;
using HELPER;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using WEB.Models.UserTest;

namespace WEB.Controllers
{
    //[Authorize]
    public class UsertTestController : Controller
    {
        private readonly UserTestDataService _userTestDataService;
        public UsertTestController(UserTestDataService userTestDataService)
        {
            _userTestDataService = userTestDataService;
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
            userTest.CreateDate = DateTime.Now;
            var result = _userTestDataService.Create(userTest);
            return Json(result);
        }
        public JsonResult Update(UserTest userTest)
        {
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
