using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsVerificationReasonViewModel
    {
        public Ms_VerificationReason Ms_VerificationReason { get; set; } = new Ms_VerificationReason();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
    }
}
