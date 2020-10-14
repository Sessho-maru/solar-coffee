using System;
using System.ComponentModel.DataAnnotations;

namespace SolarCoffee.data.models
{
    public class CustomerAddress
    {
        public int id { get; set; }

        [MaxLength(100)]
        public string addressLine1{ get; set; }

        [MaxLength(100)]
        public string addressLine2{ get; set; }

        [MaxLength(100)]
        public string city{ get; set; }

        [MaxLength(2)]
        public string state{ get; set; }

        [MaxLength(10)]
        public string postalCode{ get; set; }

        [MaxLength(32)]
        public string country{ get; set; }

        public DateTime creataedOn { get; set; }
        public DateTime updatedOn { get; set; }
    }
}