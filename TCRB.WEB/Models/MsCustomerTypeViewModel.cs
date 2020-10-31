using System.Collections.Generic;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsCustomerTypeViewModel
    {
        public Ms_CustomerType Ms_CustomerType { get; set; } = new Ms_CustomerType();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
    }
}
