using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsChannelViewModel
    {
        public Ms_Channel Ms_Channel { get; set; } = new Ms_Channel();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
    }
}
