using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HELPER
{
    public enum EnumQuestionAnswer
    {
        [Description("MobileNo")]
        MobileNo,
        [Description("DateOfBirth")]
        DateOfBirth,
        [Description("AddressCurrent")]
        AddressCurrent,
        [Description("ReleaseDate")]
        ReleaseDate,
        [Description("PmtAmt")]
        PmtAmt,
        [Description("TypeDesc")]
        TypeDesc,
        [Description("OrgAmt")]
        OrgAmt,
        [Description("Term")]
        Term,
        [Description("Branch")]
        Branch,
        [Description("LastPaymentDate")]
        LastPaymentDate,
        [Description("LastPaymentAmount")]
        LastPaymentAmount,
        [Description("NameGo")]
        NameGo,
        [Description("NameJt")]
        NameJt,
        [Description("AddressCollateral")]
        AddressCollateral,
        [Description("RegistrationNo")]
        RegistrationNo,
        [Description("Brand")]
        Brand,
        [Description("ATMCOUNT")]
        ATMCOUNT,
        [Description("TAXFREECOUNT")]
        TAXFREECOUNT,
        [Description("ACTYPECOUNT")]
        ACTYPECOUNT,
        [Description("ATMNO")]
        ATMNO,
        [Description("ATMACTYPE")]
        ATMACTYPE,
        //[Description("CURRENTADDRESS")]
        //CURRENTADDRESS,
        //[Description("ACTYPE")]
        ACTYPE,
        //[Description("BRANCH")]
        //BRANCH,
        [Description("CREDITMONTH")]
        CREDITMONTH,
        [Description("Email")]
        Email,
        [Description("CustName")]
        CustName,
        [Description("EMPTY")]
        EMPTY,
    }
}
