using System;
using System.Collections.Generic;
using System.Text;

namespace TCRB.DAL.Model.Customer
{
    public class InquiryModel
    {
        public string ChannelCode { get; set; }
        public string PhoneNo { get; set; }
        public string CitizenID_TaxID { get; set; }
        public string ProductTypeCode { get; set; }
        public string ServiceTypeCode { get; set; }
        public string TopicTypeCode { get; set; }
        public string CustomerTypeCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
