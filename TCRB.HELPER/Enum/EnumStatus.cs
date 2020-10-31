using System.ComponentModel;

namespace TCRB.HELPER
{
    public enum EnumStatus
    {
        [Description("WaitProcessing")]
        WaitProcessing,
        [Description("Processing")]
        Processing,
        [Description("Success")]
        Success,
        [Description("Error")]
        Error,
        [Description("Fail")]
        Fail,
        [Description("Lock")]
        Lock,
        [Description("UnLock")]
        UnLock,
        [Description("Y")]
        Active,
        [Description("N")]
        Inactive,
        [Description("AP")]
        Approved,
        [Description("PA")]
        PendingApprove,
        [Description("PS")]
        PendingSubmit,
        [Description("Pending")]
        Pending,
        [Description("Pass")]
        Pass
    }
}
