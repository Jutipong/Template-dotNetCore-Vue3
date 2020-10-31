using System.Collections.Generic;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsQuestionViewModel
    {
        public Ms_Question Ms_Question { get; set; } = new Ms_Question();
        public List<Select2Model> MasterLevel { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterChannel { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterProductType { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterFieldSelect { get; set; } = new List<Select2Model>();
    }
}
