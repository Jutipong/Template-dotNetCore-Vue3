namespace DAL.Model.Appsetting
{
    public class AppsittingModel
    {
        public string ProjectName { get; set; }
        public string SystemID { get; set; }
        public string UserMgmtServiceURL { get; set; }
        public string AppVersion { get; set; }
        public string AppName { get; set; }
        public int LoginTimeExpired { get; set; }
        public bool IsAuthAs400 { get; set; } = false;
        public bool IsAuthenWin { get; set; } = false;
        public ConnectionStringModel ConnectionStrings { get; set; }
        public SmsSettingsModel SmsSettings { get; set; }
        public AS400SittingModel AS400Sitting { get; set; }
        public EndpointAddressModel EndpointAddress { get; set; }

    }

    public class ConnectionStringModel
    {
        public string TCRBDB { get; set; }
        public string UserManagement { get; set; }
    }

    public class SmsSettingsModel
    {
        public string SystemName { get; set; }
        public string TimeMinute { get; set; }
        public UrlModel Url { get; set; }

        public class UrlModel
        {
            public string Base { get; set; }
            public string RequestOTP { get; set; }
            public string VerifyOTP { get; set; }
        }
    }

    public class AS400SittingModel
    {
        public string Link_AS400 { get; set; }
        public string Provider { get; set; }
        public string LibIP { get; set; }
        public int Timeout { get; set; } = 30;
    }

    public class EndpointAddressModel
    {
        public string UserManagementService { get; set; }
    }

}
