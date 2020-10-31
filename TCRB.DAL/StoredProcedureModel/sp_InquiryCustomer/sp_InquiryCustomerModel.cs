using System;
using System.Collections.Generic;
using System.Text;

namespace TCRB.DAL.StoredProcedureModel.sp_InquiryCustomer
{
    public class sp_InquiryCustomerModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ChannelCode { get; set; }
        public string PhoneNo { get; set; }
        public string CitizenID_TaxID { get; set; }
        public string ProductTypeCode { get; set; }
        public string ServiceTypeCode { get; set; }
    }
}
