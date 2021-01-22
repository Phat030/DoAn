using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class OrderDetail
    {
        [Key]
        public int IDOrderDetail { get; set; }
        public int QuantitySale { get; set; }
        public double UnitPriceSale { get; set; }
        public int IDOrder { get; set; }
        public int IDProduct { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Products { get; set; }
    }
}