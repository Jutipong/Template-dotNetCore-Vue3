using System.Collections.Generic;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models.Customer
{
    public class ReportViewModel
    {
        public List<Select2Model> MasterProductType { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterServiceType { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterChannel { get; set; } = new List<Select2Model>();
    }
}
