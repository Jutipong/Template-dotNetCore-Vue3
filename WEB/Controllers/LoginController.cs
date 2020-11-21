using DAL.Model.Commons;
using DAL.Model.UserLogin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var result = new LoginViewModel();
            return (IActionResult)View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Login");
        }

        public async Task<JsonResult> IndexAsync(LoginModel login)
        {
            var result = new ResponseModel();
            var urlAction = @Url.Action("Index", "UsertTest");
            result.Datas = urlAction;
            result.Success = true;

            return Json(result);
        }
    }
}