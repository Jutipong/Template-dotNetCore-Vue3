using System;
using System.Collections.Generic;
using System.Text;

namespace TCRB.DAL.StoredProcedureModel.sp_Report
{
    public class sp_ReportModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProductTypeCode { get; set; }
        public string ServiceTypeCode { get; set; }
        public string StaffName { get; set; }
    }
}
