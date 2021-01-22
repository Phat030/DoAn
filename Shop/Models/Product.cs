using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Product
    {
        public Product()
        {
            Image = "~/Content/Image/none.jpg";
        }
        [Key]
        public int IDProduct { get; set; }
        [Required]
        public string NameProduct { get; set; }
        [Required]
        public Nullable<int> IDCategory { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Available { get; set; }
        [Required]
        public Nullable<System.DateTime> ProductDate { get; set; }        

        [Required]
        public string Descriptions { get; set; }        

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }        
    }
}