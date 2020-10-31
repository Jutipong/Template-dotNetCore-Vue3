using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TCRB.DAL.Model.Appsetting;
using TCRB.DAL.Model.Authentication;

namespace TCRB.WEB.Controllers
{
    [Authorize]
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
