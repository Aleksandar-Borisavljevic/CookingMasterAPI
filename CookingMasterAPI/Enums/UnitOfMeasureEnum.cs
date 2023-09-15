using System.ComponentModel;

namespace CookingMasterAPI.Enums
{
    public enum UnitOfMeasureEnum
    {
        None = 0,
        [Description("gr")]
        Grams = 1,
        [Description("mL")]
        Milliliters = 2,
        [Description("pcs")]
        Pieces = 3
    }
}
