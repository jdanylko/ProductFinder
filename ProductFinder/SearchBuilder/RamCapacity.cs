using System.ComponentModel;

namespace ProductFinder.SearchBuilder
{
    public enum RamCapacity
    {
        [Description("None")]
        None = 0,
        [Description("12 GB & Up")]
        TwelveGbAndUp = 1,
        [Description("8 GB")]
        EightGb = 2,
        [Description("6 GB")]
        SixGb = 3,
        [Description("4 GB")]
        FourGb = 4,
        [Description("3 GB & Under")]
        ThreeGbAndLower = 5
    }
}