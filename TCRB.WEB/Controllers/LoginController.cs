using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using TCRB.BLL;
using TCRB.DAL.Model.Appsetting;
using TCRB.DAL.Model.Commons;
using TCRB.DAL.Model.UserLogin;
using TCRB.WEB.Helpers;
using TCRB.WEB.Models;

namespace TCRB.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppsittingModel _appsitting;
        private readonly Authentication _authentication;
        private readonly UserManagementDataService _userManagementDataService;

        public LoginController(IOptions<AppsittingModel> appsitting, Authentication authentication, UserManagementDataService userManagementDataService)
        {
            _appsitting = appsitting.Value;
            _authentication = authentication;
            _userManagementDataService = userManagementDataService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var result = new LoginViewModel();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete($".{_appsitting.ProjectName}");
#if DEBUG
            HttpContext.Response.Cookies.Delete($".{_appsitting.ProjectName}.Dev");
            result = new LoginViewModel
            {
                IsAuthAs400 = _appsitting.IsAuthAs400,
                IsAuthenWin = _appsitting.IsAuthenWin,
                UserName = "Tmpbpm001",
                Password = "Password1",
                UserNameAs400 = "TCSOFR04",
                PasswordAs400 = "password"
            };
#endif
            return (IActionResult)View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete($".{_appsitting.ProjectName}");
#if DEBUG
            HttpContext.Response.Cookies.Delete($".{_appsitting.ProjectName}.Dev");
#endif
            return RedirectToAction("Index", "Login");
        }

        public async Task<JsonResult> IndexAsync(LoginModel login)
        {
            var result = new ResponseModel();
            var urlAction = @Url.Action("Index", "UsertTest");

#if DEBUG
            result.Datas = urlAction;
            result.Success = true;
            return Json(result);
#endif


            try
            {
                if (_appsitting.IsAuthenWin)
                {
                    var adUser = User.Identity?.Name;
                    //var adUser = @"TCBANK\T58120";

                    if (!string.IsNullOrWhiteSpace(adUser) && adUser.Contains(@"\"))
                    {
                        var user = adUser.Split(@"\")?.Last();
                        var emp = _userManagementDataService.InquiryADUser(user);
                    }

                    result.Datas = urlAction;
                    result.Success = true;
                }
                else
                {
                    //Authentication Webservice
                    var userLoginWs = await _authentication.WebserviceAsync(login);
                    if (userLoginWs.Success)
                    {
                        var claims = new List<Claim> {
                        new Claim(ClaimTypes.UserData, JsonSerializer.Serialize(userLoginWs.Datas)),
                        new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()),
                        };
                        foreach (var item in userLoginWs.Datas.Permissions)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, item.ID));
                        }

                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        await HttpContext.SignInAsync(principal, new AuthenticationProperties
                        {
                            IsPersistent = false,
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(_appsitting.LoginTimeExpired)
                        });

                        result.Datas = urlAction;
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = userLoginWs.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return Json(result);
        }

        public ResponseModel AuthAs400(LoginModel login)
        {
            var result = new ResponseModel();
            var urlAction = @Url.Action("Index", "Dashboard");
            try
            {
                result = _authentication.AuthAs400(login);
                if (result.Success)
                {
                    result.Datas = urlAction;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
    }
}