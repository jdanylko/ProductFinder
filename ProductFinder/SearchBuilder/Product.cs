using System;
using System.ComponentModel.DataAnnotations;
using ProductFinder.Extensions;

namespace ProductFinder.SearchBuilder
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public ProcessorType Processor { get; set; }
        public RamCapacity RAM { get; set; }

        public string ProcessorWord => Processor.ToDescription();
        public string RAMWord => RAM.ToDescription();
    }
}
