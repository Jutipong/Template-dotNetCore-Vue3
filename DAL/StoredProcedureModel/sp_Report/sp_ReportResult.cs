using System;
using System.Collections.Generic;
using System.Text;

namespace TCRB.DAL.StoredProcedureModel.sp_Report
{
    public class sp_ReportResult
    {
        public List<HeaderModel> Headers { get; set; } = new List<HeaderModel>();
        public List<DetailModel> Details { get; set; } = new List<DetailModel>();

        public class HeaderModel
        {
            public Guid VerifyCustomerID { get; set; }
            public DateTime CreateDate { get; set; }
            public string PhoneNo { get; set; }
            public string PhoneSendOTP { get; set; }
            private string _CitizenIDTaxID = string.Empty;
            public string CitizenIDTaxID
            {
                get
                {
                    return _CitizenIDTaxID;
                }
                set
                {
                    _CitizenIDTaxID = value;
                }
            }

            private string _CitizenID_TaxID = string.Empty;
            public string CitizenID_TaxID
            {
                get
                {
                    return _CitizenIDTaxID;
                }
                set
                {
                    _CitizenID_TaxID = value;
                }
            }
            public string ProductTypeName { get; set; }
            public string ChanelName { get; set; }
            public string ServiceTypeName { get; set; }
            public string VerifyTypeName { get; set; }
            public string ResultOfVerify { get; set; }
            public string EndCallReasonName { get; set; }
            public string StaffName { get; set; }
        }

        public class DetailModel
        {
            public Guid VerifyCustomerID { get; set; }
            public int? Running { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
            public string Result { get; set; }
        }
    }
}
