using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductFinder.SearchBuilder
{
    public interface ISearchParameters
    {
        string SearchTerm { get; set; }
        SortCriteria SortBy { get; set; }
        List<SelectListItem> ProcessorList { get; set; }
        List<SelectListItem> RamList { get; set; }
        int ReviewRating { get; set; }
        double PriceLow { get; set; }
        double PriceHigh { get; set; }
        bool NewArrival { get; set; }
        bool EmptyParameters { get; }
    }
}