﻿using System.ComponentModel;

namespace HELPER
{
    public enum EnumRole
    {
        [Description("ADMIN")]
        ADMIN,
        [Description("MAKER")]
        MAKER,
        [Description("CHECKER")]
        CHECKER,
        [Description("APPROVER")]
        APPROVER,
        [Description("VIEWER")]
        VIEWER,
    }

}
