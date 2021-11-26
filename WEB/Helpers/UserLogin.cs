using DAL.Model.Authentication;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Web;

namespace WEB
{
    public class UserLogin
    {
        public UserLoginModel UserProfile()
        {
            var userCurrent = HttpContext.Current.User;
            var userJson = userCurrent.Claims.Where(u => u.Type == ClaimTypes.Sid).Select(r => r.Value).FirstOrDefault();
            var userdatajson = userCurrent.Claims.Where(u => u.Type == ClaimTypes.UserData).Select(r => r.Value).FirstOrDefault();
            if (userdatajson != null)
            {
                var user = JsonSerializer.Deserialize<UserLoginModel>(userdatajson);
                return user;
            }
            else
            {
                return new UserLoginModel();
            }
        }
    }
}
