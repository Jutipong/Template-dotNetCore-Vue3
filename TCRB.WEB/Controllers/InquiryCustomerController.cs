using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TCRB.DAL.Model.Appsetting;
using TCRB.DAL.Model.Authentication;
using TCRB.DAL.Model.Commons;
using TCRB.DAL.StoredProcedureModel.sp_InquiryCustomer;

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

        public JsonResult InquiryMasterDatatable(DatableOption option, sp_InquiryCustomerModel spInquiryCustomer)
        {
            return Json(null);
        }
    }
}
