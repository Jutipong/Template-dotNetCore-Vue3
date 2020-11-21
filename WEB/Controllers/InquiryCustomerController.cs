using DAL.Model.Appsetting;
using DAL.Model.Authentication;
using DAL.Model.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TCRB.WEB.Controllers
{
    //[Authorize]
    public class InquiryCustomerController : Controller
    {
        private readonly AppsittingModel _appsitting;
        private readonly UserLoginModel _userLogin;

        public InquiryCustomerController(
           IOptions<AppsittingModel> appsitting,
           UserLogin userLogin)
        {
            _appsitting = appsitting.Value;
            _userLogin = userLogin.UserProfile();
        }

        //[TypeFilter(typeof(AccessPermissionFilter))]
        public IActionResult Index()
        {
            return View(null);
        }
    }
}
