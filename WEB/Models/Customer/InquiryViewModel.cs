using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using TCRB.DAL.Model.Commons;
using TCRB.DAL.StoredProcedureModel;

namespace TCRB.WEB.Models.Customer
{
    public class InquiryViewModel
    {
        public List<SelectListItem> MasterProductType { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> MasterServiceType { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> MasterChannel { get; set; } = new List<SelectListItem>();
    }
}
