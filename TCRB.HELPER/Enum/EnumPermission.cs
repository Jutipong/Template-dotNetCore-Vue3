using System.ComponentModel;

namespace TCRB.HELPER.Enum
{
    public enum EnumPermission
    {
        [Description("S01001")]
        InboundAgent,
        [Description("S01002")]
        InboundSupervisor,
        [Description("S01003")]
        ChatAgent,
        [Description("S01004")]
        ChatSupervisor,
        [Description("S01005")]
        BackOffice,
        [Description("S01006")]
        BusinessAdmin,
        [Description("S01007")]
        QA,
        [Description("S01008")]
        Fraud,
    }
}
