using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using ProductFinder.Extensions;

namespace ProductFinder.SearchBuilder
{
    public class SearchParameters : ISearchParameters
    {
        public string SearchTerm { get; set; }
        public SortCriteria SortBy { get; set; }
        public List<SelectListItem> ProcessorList { get; set; }
        public List<SelectListItem> RamList { get; set; }
        public int ReviewRating { get; set; }
        public double PriceLow { get; set; }
        public double PriceHigh { get; set; }
        public bool NewArrival { get; set; }

        public SearchParameters()
        {
            // Default values
            SearchTerm = String.Empty;
            SortBy = SortCriteria.Relevance;
            ProcessorList = typeof(ProcessorType).ToSelectList<ProcessorType>();
            RamList = typeof(RamCapacity).ToSelectList<RamCapacity>();
            ReviewRating = 0;
            PriceLow = PriceHigh = 0.00;
            NewArrival = false;
        }

        public bool EmptyParameters
        {
            get
            {
                var emptySearch = String.IsNullOrEmpty(SearchTerm);
                var emptyProcessor = ProcessorList.Count(e => e.Selected) == 0;
                var emptyRam = RamList.Count(e => e.Selected) == 0;
                return emptySearch && emptyProcessor && emptyRam;
            }
        }
    }
}