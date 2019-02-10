using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using PredicateExtensions;

namespace ProductFinder.SearchBuilder
{
    public class ProductBuilder
    {
        private readonly ISearchParameters _searchParameters;

        public ProductBuilder()
        {
            _searchParameters = new SearchParameters();
        }

        public ProductBuilder(ISearchParameters searchParameters)
        {
            _searchParameters = searchParameters;
        }
        
        public ProductBuilder SetSearchTerm(string searchTerm)
        {
            _searchParameters.SearchTerm = searchTerm;
            return this;
        }
        
        public ProductBuilder SortBy(SortCriteria criteria)
        {
            _searchParameters.SortBy = criteria;
        
            return this;
        }
        
        public ProductBuilder SetProcessor(List<SelectListItem> processors)
        {
            _searchParameters.ProcessorList = new List<SelectListItem>(processors);
            return this;
        }
        
        public ProductBuilder SetRAM(List<SelectListItem> capacities)
        {
            _searchParameters.RamList = new List<SelectListItem>(capacities);
            return this;
        }
        
        public ProductBuilder SetReviewRating(int rating)
        {
            _searchParameters.ReviewRating = rating;
            return this;
        }
        
        public ProductBuilder SetLowPrice(double lowPrice)
        {
            _searchParameters.PriceLow = lowPrice;
            return this;
        }
        
        public ProductBuilder SetHighPrice(double highPrice)
        {
            _searchParameters.PriceHigh = highPrice;
            return this;
        }
    
        public ProductBuilder SetNewArrival(bool newArrival)
        {
            _searchParameters.NewArrival = newArrival;
            return this;
        }

        public Expression<Func<Product, bool>> Build()
        {
            // old and busted
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Product>();

            // Search Term
            if (!String.IsNullOrEmpty(_searchParameters.SearchTerm))
            {
                predicate = predicate.And(
                    e => e.Title.Contains(_searchParameters.SearchTerm));
            }
            
            // Price
            if (_searchParameters.PriceHigh > 0 && _searchParameters.PriceLow > 0)
            {
                predicate = predicate.And(
                    e => e.Price >= _searchParameters.PriceLow 
                         && e.Price <= _searchParameters.PriceHigh);
            }
            
            // RAM
            var selected = _searchParameters.RamList.FirstOrDefault(e => e.Selected) != null;
            if (selected)
            {
                foreach (var item in _searchParameters.RamList)
                {
                    if (item.Selected)
                    {
                        predicate = predicate.Or(e => ((int)e.RAM).ToString() == item.Value);
                    }
                }
            }
            
            // Processor
            selected = _searchParameters.ProcessorList.FirstOrDefault(e => e.Selected) != null;
            if (selected)
            {
                foreach (var item in _searchParameters.ProcessorList)
                {
                    if (item.Selected)
                    {
                        predicate = predicate.Or(e => ((int)e.Processor).ToString() == item.Value);
                    }
                }
            }
            
            // Rating
            if (_searchParameters.ReviewRating > 0)
            {
                predicate = predicate.And(
                    e => e.Rating >= _searchParameters.ReviewRating);
            }
            
            // either execute the query here...
            // var records = dbContext.Products.Where(predicate);
            // Sorting - no test.
            //switch (_searchParameters.SortBy)
            //{
            //    case SortCriteria.PriceHighToLow:
            //        records = records.OrderByDescending(e => e.Price);
            //        break;
            //    case SortCriteria.PriceLowToHigh:
            //        records = records.OrderBy(e => e.Price);
            //        break;
            //}
            // or just return the predicate for filtering outside the method.
            
            return predicate;
        }
    }
}