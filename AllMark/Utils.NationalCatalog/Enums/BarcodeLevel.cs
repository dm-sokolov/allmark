using System.Runtime.Serialization;

namespace Utils.NationalCatalog.Enums
{
    public enum BarcodeLevel
    {
        [EnumMember(Value = "trade-unit")]
        TradeUnit = 1,
        Box = 2,
        Layer = 3,
        Pallet = 4,
        [EnumMember(Value = "metro-unit")]
        MetroUnit = 5,
        [EnumMember(Value = "show-pack")]
        ShowPack = 6,
        [EnumMember(Value = "inner-pack")]
        InnerPack = 7
    }
}
