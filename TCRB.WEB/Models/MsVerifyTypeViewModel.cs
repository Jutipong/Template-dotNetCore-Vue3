using System.Collections.Generic;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsVerifyTypeViewModel
    {
        public Ms_VerifyType Ms_VerifyType { get; set; } = new Ms_VerifyType();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();

    }
}
