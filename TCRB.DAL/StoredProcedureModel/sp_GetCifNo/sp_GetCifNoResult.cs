using System;
using System.Collections.Generic;
using System.Text;

namespace TCRB.DAL.StoredProcedureModel.sp_GetCifNo
{
    public class sp_GetCifNoResult
    {
        public decimal? CifNo { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
    }
}
