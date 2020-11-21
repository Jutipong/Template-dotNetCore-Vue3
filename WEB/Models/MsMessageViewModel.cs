using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsMessageViewModel
    {
        public Ms_Message Ms_Message { get; set; } = new Ms_Message();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterResultOfVerify { get; set; } = new List<Select2Model>();
    }
}
