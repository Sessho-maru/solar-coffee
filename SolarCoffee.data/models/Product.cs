using System;
using System.ComponentModel.DataAnnotations;

namespace SolarCoffee.data.models
{
    public class Product
    {
        public int id { get; set; }
        public DateTime creataedOn { get; set; }
        public DateTime updatedOn { get; set; }

        [MaxLength(64)]
        public string name { get; set;}
        [MaxLength(128)]
        public string description { get; set; }

        public decimal price { get; set; }
        public bool isTaxable { get; set; }
        public bool isArchived { get; set; }
    }
}