using System.ComponentModel;

namespace Utils.NationalCatalog.Enums
{
    /// <summary>
    /// тип фотографии
    /// </summary>
    public enum PhotoType
    {
        [Description("crop-фотография для планограмм (обрезанная по контуру товара)")]
        Facing = 1
    }
}
