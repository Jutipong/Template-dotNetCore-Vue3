namespace TCRB.WEB.Models
{
    public class LoginViewModel
    {
        public bool IsAuthAs400 { get; set; } = false;
        public bool IsAuthenWin { get; set; } = false;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserNameAs400 { get; set; }
        public string PasswordAs400 { get; set; }
    }
}
