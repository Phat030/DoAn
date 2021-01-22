using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Order
    {
        [Key]
        public int IDOrder { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [Required]
        public string AddressDelivery { get; set; }   
        public int PhoneCus { get; set; }        
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}