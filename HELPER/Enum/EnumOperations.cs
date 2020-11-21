using System.ComponentModel;

namespace TCRB.HELPER
{
    public enum EnumOperations
    {
        [Description("CREATE")]
        CREATE = 1,
        [Description("UPDATE")]
        UPDATE = 2,
        [Description("DELETE")]
        DELETE = 3,
        [Description("EDIT")]
        EDIT = 4,
        [Description("NEW")]
        NEW = 5,
        [Description("SAVE")]
        SAVE = 6,
        [Description("SUBMIT")]
        SUBMIT = 7,
        [Description("READ")]
        READ = 8,
        [Description("APPROVE")]
        APPROVE,
        [Description("REJECT")]
        REJECT,
        [Description("ACTIVE")]
        ACTIVE,
        [Description("INACTIVE")]
        INACTIVE

    }
}
