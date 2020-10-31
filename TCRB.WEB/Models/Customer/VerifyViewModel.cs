using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models.Customer
{
    public class VerifyCustomerViewModel
    {
        public Guid TokenID { get; set; } = Guid.NewGuid();
        public VerifyCustomer VerifyCustomer { get; set; } = new VerifyCustomer();
        public List<VerifyQuestion> VerifyQuestion { get; set; } = new List<VerifyQuestion>();

        public List<Ms_QuestionModel> QuestionsList { get; set; } = new List<Ms_QuestionModel>();
        public List<Config_WrongAnswer> ConfigWrongAnswer { get; set; } = new List<Config_WrongAnswer>();
        public List<Config_OTP> Config_OTPs { get; set; } = new List<Config_OTP>();
        public List<Select2Model> MasterChannel { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterProductType { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterServiceType { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterTopicType { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterCustomerType { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterEndCallReason { get; set; } = new List<Select2Model>();
        public List<Ms_EndCallReason> MasterMessage { get; set; }
        //public List<Ms_Message> MasterMessage { get; set; }
    }

    public class Ms_QuestionModel : Ms_Question
    {
        public bool IsRowActive { get; set; } = true;
    }
}
