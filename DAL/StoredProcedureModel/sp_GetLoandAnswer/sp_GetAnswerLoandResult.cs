using System;
using System.Collections.Generic;
using System.Text;

namespace TCRB.DAL.StoredProcedureModel.sp_GetLoandAnswer
{
    public class sp_AnswerLoandResult
    {
        public List<sp_GetAnswerLoandResult1> Result1 { get; set; } = new List<sp_GetAnswerLoandResult1>();
        public List<sp_GetAnswerLoandResult2> Result2 { get; set; } = new List<sp_GetAnswerLoandResult2>();
        public List<sp_GetAnswerLoandResult3> Result3 { get; set; } = new List<sp_GetAnswerLoandResult3>();
        public List<sp_GetAnswerLoandResult4> Result4 { get; set; } = new List<sp_GetAnswerLoandResult4>();
        public List<sp_GetAnswerLoandResult5> Result5 { get; set; } = new List<sp_GetAnswerLoandResult5>();
        public List<sp_GetAnswerLoandResult6> Result6 { get; set; } = new List<sp_GetAnswerLoandResult6>();
        public List<sp_GetAnswerLoandResult7> Result7 { get; set; } = new List<sp_GetAnswerLoandResult7>();
    }

    public class sp_GetAnswerLoandResult1
    {
        public string MobileNo { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }

    public class sp_GetAnswerLoandResult2
    {
        public string AddressCurrent { get; set; }
    }

    public class sp_GetAnswerLoandResult3
    {
        public DateTime? ReleaseDate { get; set; }
        public decimal? Pmtamt { get; set; }
        public string TypeDesc { get; set; }
        public decimal? OrgAmt { get; set; }
        public decimal? Term { get; set; }
        public string Branch { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public decimal? LastPaymentAmount { get; set; }
        public string CustName { get; set; }
    }

    public class sp_GetAnswerLoandResult4
    {
        public string NameGo { get; set; }

    }

    public class sp_GetAnswerLoandResult5
    {
        public string NameJt { get; set; }

    }
    public class sp_GetAnswerLoandResult6
    {
        //public string CCDNAM { get; set; }
        //public string CCLOC1 { get; set; }
        //public string CCLOC2 { get; set; }
        //public string CCLOC3 { get; set; }
        public string AddressCollateral { get; set; }
    }
    public class sp_GetAnswerLoandResult7
    {
        public string RegistrationNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
