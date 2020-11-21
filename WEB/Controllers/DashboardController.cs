using DAL.Model.Appsetting;
using DAL.Model.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WEB.Controllers
{
    //[Authorize]
    public class DashboardController : Controller
    {
        private readonly AppsittingModel _appsitting;
        private readonly UserLoginModel _userLogin;

        public DashboardController(
           IOptions<AppsittingModel> appsitting,
           UserLogin userLogin)
        {
            _appsitting = appsitting.Value;
            _userLogin = userLogin.UserProfile();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo01()
        {
            return View();
        }
    }
}
