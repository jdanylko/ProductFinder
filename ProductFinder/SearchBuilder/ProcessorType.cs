using System.ComponentModel;

namespace ProductFinder.SearchBuilder
{
    public enum ProcessorType
    {
        [Description("None")]
        None = 0,
        [Description("Intel Core i5")]
        IntelCorei5 = 1,
        [Description("Intel Core i7")]
        IntelCorei7 = 2,
        [Description("Intel Core i3")]
        IntelCorei3 = 3,
        [Description("Intel Core 2")]
        IntelCore2 = 4,
        [Description("Intel Xeon")]
        IntelXeon = 5
    }
}