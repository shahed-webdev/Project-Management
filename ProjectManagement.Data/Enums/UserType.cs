using System.ComponentModel;

namespace ProjectManagement.Data
{
    public enum UserType
    {
        [Description("Admin")]
        Admin,

        [Description("Read Only")]
        ReadOnly,

        [Description("Full Exist")]
        FullExist,
    }
}