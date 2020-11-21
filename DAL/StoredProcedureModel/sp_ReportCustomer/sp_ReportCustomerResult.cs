using System;
using System.Collections.Generic;
using System.Text;

namespace TCRB.DAL.StoredProcedureModel.sp_ReportCustomer
{
    public class sp_ReportCustomerResult
    {
        public HeaderModel Header { get; set; }
        public DetailModel Detail { get; set; }


        public class HeaderModel
        {
            public Guid ID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string ProductTypeName { get; set; }
            public string ServiceTpeName { get; set; }
            public string StaffName { get; set; }
        }

        public class DetailModel
        {
            public Guid ID { get; set; }
            public int Running { get; set; }
            public DateTime CreateDate { get; set; }
            public string PhoneNo { get; set; }
            public string CitizenID_TaxID { get; set; }
            public string PhoneSendOTP { get; set; }
            public string ProductTypeName { get; set; }
            public string ServiceTypeName { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }
            public string Result { get; set; }
            public string ResultOfVerify { get; set; }
            public string EndCallReasonName { get; set; }
            public string CreateByName { get; set; }
        }
    }

}
