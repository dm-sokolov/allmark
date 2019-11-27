using System.Runtime.Serialization;

namespace Utils.NationalCatalog
{
    public enum StatusId
    {
        [EnumMember(Value = "0")]
        Rejected = 0,

        [EnumMember(Value = "1")]
        Received = 1,

        [EnumMember(Value = "2")]
        Moderated = 2,

        [EnumMember(Value = "3")]
        Signed = 3
    }
}