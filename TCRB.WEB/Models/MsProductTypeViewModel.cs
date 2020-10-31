using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsProductTypeViewModel
    {
        public Ms_ProductType Ms_ProductType { get; set; } = new Ms_ProductType();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
    }
}
