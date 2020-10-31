using System;
using System.Collections.Generic;

namespace TCRB.DAL.StoredProcedureModel.sp_GetDepositAnswer
{
    public class sp_GetAnswerDepositResult
    {
        public List<sp_GetAnswerDepositResult1> Result1 { get; set; } = new List<sp_GetAnswerDepositResult1>();
    }

    public class sp_GetAnswerDepositResult1
    {
        public int? ATMCOUNT { get; set; }
        public int? TAXFREECOUNT { get; set; }
        public int? ACTYPECOUNT { get; set; } //==========
        public string ATMNO { get; set; } //==========
        public string ATMACTYPE { get; set; }
        public string MOBILE { get; set; }
        public DateTime? DateOfBirth { get; set; }


        public string CURRENTADDRESS { get; set; }
        public string ACTYPE { get; set; }
        public string BRANCH { get; set; }
        public decimal? CREDITMONTH { get; set; }
        public string Emial { get; set; }
    }
}
