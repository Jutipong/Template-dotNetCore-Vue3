using System.ComponentModel;

namespace HELPER
{
    public enum EnumHttpStatus
    {
        [Description("Internal Server Error.")]
        INTERNAL_SERVER_ERROR,
        [Description("Success.")]
        SUCCESS,
        [Description("Data NotFound.")]
        DATANOTFOUND,
        [Description("Data Authentication.")]
        AUTHENTICATION,
        [Description("Data already Exists!.")]
        ALREADY,
    }
}
