using System.Collections.Generic;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsLeveViewModel
    {
        public Ms_Level Ms_Level { get; set; } = new Ms_Level();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
    }
}
