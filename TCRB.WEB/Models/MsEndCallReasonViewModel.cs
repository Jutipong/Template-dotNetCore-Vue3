using System.Collections.Generic;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsEndCallReasonViewModel
    {
        public Ms_EndCallReason Ms_EndCallReason { get; set; } = new Ms_EndCallReason();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterResultOfVerify { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterType { get; set; } = new List<Select2Model>();
    }
}
