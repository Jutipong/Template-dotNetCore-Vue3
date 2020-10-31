using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class ConfigOTPViewModel
    {
        public Config_OTP Config_OTP { get; set; } = new Config_OTP();
        public List<Select2Model> MasterChannel { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterOTPType { get; set; } = new List<Select2Model>();
    }
}
