using System;
using System.Collections.Generic;
using System.Text;

namespace TCRB.DAL.StoredProcedureModel.sp_InquiryCustomer
{
    public class sp_InquiryCustomerResult
    {
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string PhoneNo { get; set; }

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
        public string ProductTypeCode { get; set; }
        public string ProductTypeName { get; set; }
        public string ServiceTypeCode { get; set; }
        public string ServiceTypeName { get; set; }
        public string ChannelCode { get; set; }
        public string ChannelName { get; set; }
        public string PhoneSendOTP { get; set; }
        public string ResultOfVerify { get; set; }
        public string EndCallReasonCode { get; set; }
        public string EndCallReasonName { get; set; }
        public string CreateByCode { get; set; }
        public string CreateByName { get; set; }
        public int TotalRows { get; set; }
    }
}
