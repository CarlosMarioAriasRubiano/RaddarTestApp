using System.ComponentModel;

namespace RaddarTestApp.Domain.Enums
{
    public enum ItemQueryConstants
    {
        [Description("GetProductById")]
        GetProductById,
        [Description("GetProducts")]
        GetProducts,
        [Description("GetUserByUserName")]
        GetUserByUserName,
        [Description("GetUserByUserNameAndPassword")]
        GetUserByUserNameAndPassword,
        [Description("GetUserByEmail")]
        GetUserByEmail
    }
}
