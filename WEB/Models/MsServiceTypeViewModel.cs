using System.Collections.Generic;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsServiceTypeViewModel
    {
        public Ms_ServiceType Ms_ServiceType { get; set; } = new Ms_ServiceType();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
    }
}
