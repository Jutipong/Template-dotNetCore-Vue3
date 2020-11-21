namespace TCRB.DAL.Model.Sms
{
    public class OTPMessage
    {
        public string Tel { get; set; }
        public string ADUser { get; set; }
        public string SystemName { get; set; }
        public string TimeMinute { get; set; }
    }

    public class ReferidOTP
    {
        public string referid { get; set; }
        public string otpcode { get; set; }
        public string tel { get; set; }
    }
}
