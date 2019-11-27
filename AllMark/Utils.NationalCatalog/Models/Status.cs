using System.Runtime.Serialization;

namespace Utils.NationalCatalog
{
    public enum Status
    {
        [EnumMember(Value = "Rejected")]
        Rejected = 0,

        [EnumMember(Value = "Received")]
        Received = 1,

        [EnumMember(Value = "Moderated")]
        Moderated = 2,

        [EnumMember(Value = "Signed")]
        Signed = 3
    }
}